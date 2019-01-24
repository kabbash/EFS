﻿using Attachments.Core.Models;
using Mapster;
using Shared.Core.Models.Base;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Attachments.Core.Interfaces
{
    public class SliderManager<T> : ISliderManager<T> where T : IImageBase
    {
        private readonly IAttachmentsManager _attachmentsManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;

        public SliderManager(IUnitOfWork unitOfWork, IAttachmentsManager attachmentsManager)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.getRepoByType(typeof(IRepository<T>)) as IRepository<T>;
            _attachmentsManager = attachmentsManager;
        }

        public bool Add(SliderDto dto)
        {
            try
            {
                dto.Items.ForEach(c =>
                    {

                        if (!c.IsProfilePicture)
                            c.Path = _attachmentsManager.Save(new SavedFileDto
                            {
                                attachmentType = dto.attachmentType,
                                CanChangeName = true,
                                File = c.File,
                                SubFolderName = dto.ParentId.ToString()
                            });

                        var Obj = c.Adapt<T>();
                        Obj.ParentId = dto.ParentId;
                        _repository.Insert(Obj);
                    });

                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(SliderDto dto)
        {
            try
            {
                //added images
                dto.Items.Where(c => c.IsNew).ToList().ForEach(c =>
                {
                    if (!c.IsProfilePicture)
                        c.Path = _attachmentsManager.Save(new SavedFileDto
                        {
                            attachmentType = dto.attachmentType,
                            CanChangeName = true,
                            File = c.File,
                            SubFolderName = dto.ParentId.ToString()
                        });

                    _repository.Insert(c.Adapt<T>());
                });

                //updated images
                dto.Items.Where(c => c.IsDataUpdated && !c.IsDeleted).ToList().ForEach(c =>
               {
                   var oldImage = _repository.GetById(c.Id);
                   if (oldImage != null)
                   {
                       var updatedObj = c.Adapt<T>();
                       updatedObj.ParentId = dto.ParentId;
                       _repository.Update(updatedObj);
                       _unitOfWork.Commit();
                   }
               });

                //deleted images
                dto.Items.Where(c => c.IsDeleted && !string.IsNullOrEmpty(c.Path)).ToList().ForEach(c =>
                {
                    _attachmentsManager.Delete(c.Path);

                    var Obj = _repository.GetById(c.Id);
                    if (Obj != null)
                        _repository.Delete(c.Id);
                });

                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Delete(SliderDto dto)
        {

            try
            {
                dto.Items.Where(c => !string.IsNullOrEmpty(c.Path)).ToList().ForEach(c =>
                   {
                       _attachmentsManager.Delete(c.Path);

                       var Obj = _repository.GetById(c.Id);
                       if (Obj != null)
                           _repository.Delete(c.Id);
                   });

                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string GetProfilePicturePath(SliderDto dto)
        {
            foreach (var c in dto.Items)
            {
                if (!c.IsDeleted && c.IsProfilePicture)
                {
                    if (c.IsNew)
                        return _attachmentsManager.Save(new SavedFileDto
                        {
                            attachmentType = dto.attachmentType,
                            CanChangeName = true,
                            File = c.File,
                            SubFolderName = dto.SubFolderName
                        });              
                    else
                        return c.Path;
                }
            }
            return null;
        }
    }
}
