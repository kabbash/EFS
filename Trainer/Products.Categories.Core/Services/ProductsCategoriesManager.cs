using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Products.Core.Interfaces;
using Products.Core.Models;
using Shared.Core;
using Shared.Core.Models;
using Shared.Core.Resources;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Net;

namespace Products.Core.Services
{
    public class ProductsCategoriesManager : IProductsCategoriesManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<ProductsCategoryDto> _validator;
        private readonly IOptions<ProductsResources> _productsResources;
        private readonly IAttachmentsManager _attachmentsManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductsCategoriesManager(IUnitOfWork unitOfWork, IValidator<ProductsCategoryDto> validator, IOptions<ProductsResources> productsResources, IAttachmentsManager attachmentsManager, IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _productsResources = productsResources;
            _attachmentsManager = attachmentsManager;
            _hostingEnvironment = hostingEnvironment;
        }
        public ResultMessage GetAll()
        {
            try
            {
                IEnumerable<ProductsCategoryDto> result = new List<ProductsCategoryDto>();
                result = _unitOfWork.ProductsCategoriesRepository.Get().Adapt(result);

                return new ResultMessage()
                {
                    Data = result,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                //log ex
                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsCategoriesGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Insert(ProductsCategoryDto category)
        {
            var validationResult = _validator.Validate(category);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {
                var newCategory = category.Adapt<ProductsCategories>();
                newCategory.CreatedAt = DateTime.Now;
                newCategory.CreatedBy = "7c654344-ad42-4428-a77a-00a8c1299c3f";
                newCategory.ProfilePicture = _attachmentsManager.Save(new SavedFileDto
                {
                    File = category.profilePictureFile,
                    attachmentType = AttachmentTypesEnum.Products_Categories,
                    CanChangeName = true
                });

                _unitOfWork.ProductsCategoriesRepository.Insert(newCategory);
                _unitOfWork.Commit();
                return new ResultMessage()
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsCategoriesInsertError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetById(int id)
        {
            try
            {
                var category = _unitOfWork.ProductsCategoriesRepository.GetById(id);
                if (category != null)
                    return new ResultMessage()
                    {
                        Data = category.Adapt<ProductsCategoryDto>(),
                        Status = HttpStatusCode.OK
                    };
                else
                    return new ResultMessage()
                    {
                        Status = HttpStatusCode.NotFound,
                        ErrorCode = (int)ProductsErrorsCodeEnum.ProductsCategoriesNotFoundError
                    };
            }
            catch (Exception ex)
            {
                //log ex
                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsCategoriesGetByIdError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Update(ProductsCategoryDto category, int id)
        {
            var validationResult = _validator.Validate(category);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {
                var oldCategory = _unitOfWork.ProductsCategoriesRepository.GetById(id);
                if (oldCategory != null)
                {
                    oldCategory.Name = category.Name;
                    oldCategory.ProfilePicture = category.ProfilePicture;
                    oldCategory.ParentId = category.ParentId;
                    oldCategory.UpdatedBy = "7c654344-ad42-4428-a77a-00a8c1299c3f";
                    oldCategory.UpdatedAt = DateTime.Now;

                    _unitOfWork.ProductsCategoriesRepository.Update(oldCategory);
                    _unitOfWork.Commit();
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.OK
                    };
                }
                else
                {
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound,
                        ErrorCode = (int)ProductsErrorsCodeEnum.ProductsCategoriesNotFoundError
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsCategoriesUpdateError
                };
            }
        }
        public ResultMessage Delete(int id)
        {
            try
            {
                _unitOfWork.ProductsCategoriesRepository.Delete(id);
                _unitOfWork.Commit();
                return new ResultMessage()
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsCategoriesDeleteError
                };
            }
        }

    }
}
