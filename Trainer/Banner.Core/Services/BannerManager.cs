using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using Banner.Core.Interfaces;
using Banner.Core.Models;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.Logging;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Models;
using System;
using System.Net;

namespace Banner.Core.Services
{
    public class BannerManager : IBannerManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<BannerDto> _validator;
        private readonly IAttachmentsManager _attachmentsManager;
        private readonly ILogger<IBannerManager> _logger;
        public BannerManager(IUnitOfWork unitOfWork, IValidator<BannerDto> validator, IAttachmentsManager attachmentsManager, ILogger<IBannerManager> logger)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _attachmentsManager = attachmentsManager;
            _logger = logger;
        }
        public ResultMessage Add(BannerDto banner)
        {
            var validationResult = _validator.Validate(banner);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {
                var newBanner = banner.Adapt<Shared.Core.Models.Banner>();
                newBanner.CreatedAt = DateTime.Now;
                newBanner.ImagePath = _attachmentsManager.Save(new SavedFileDto
                {
                    File = banner.ImageFile,
                    attachmentType = AttachmentTypesEnum.Banners,
                    CanChangeName = true
                });

                _unitOfWork.BannersRepository.Insert(newBanner);
                _unitOfWork.Commit();
                return new ResultMessage()
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsCategoriesInsertError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }

        public ResultMessage Delete(int id)
        {
            try
            {
                var banner = _unitOfWork.BannersRepository.GetById(id);
                _attachmentsManager.Delete(banner.ImagePath);
                _unitOfWork.BannersRepository.Delete(id);
                _unitOfWork.Commit();
                return new ResultMessage()
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = (int)BannersErrorsCodeEnum.DeleteError
                };
            }
        }

        public ResultMessage Get(int pageNo, int pageSize)
        {
            PagedResult<BannerDto> result = new PagedResult<BannerDto>();
            result = _unitOfWork.BannersRepository.Get().GetPaged(pageNo, pageSize).Adapt(result);

            return new ResultMessage()
            {
                Data = result,
                Status = HttpStatusCode.OK
            };
        }

        public ResultMessage GetById(int id)
        {
            var banner = _unitOfWork.BannersRepository.GetById(id);
            if (banner != null)
                return new ResultMessage()
                {
                    Data = banner.Adapt<BannerDto>(),
                    Status = HttpStatusCode.OK
                };
            else
                return new ResultMessage()
                {
                    Status = HttpStatusCode.NotFound,
                    ErrorCode = (int)BannersErrorsCodeEnum.NotFoundError
                };
        }

        public ResultMessage Update(BannerDto banner, int id)
        {
            try
            {
                var oldBanner = _unitOfWork.BannersRepository.GetById(id);
                if (oldBanner != null)
                {
                    if (banner.ImageFile != null)
                    {
                        _attachmentsManager.Delete(banner.ImagePath);
                        banner.ImagePath = _attachmentsManager.Save(new SavedFileDto
                        {
                            attachmentType = AttachmentTypesEnum.Banners,
                            CanChangeName = true,
                            File = banner.ImageFile
                        });
                    }
                    banner.Adapt(oldBanner, typeof(BannerDto), typeof(Shared.Core.Models.Banner));
                    _unitOfWork.BannersRepository.Update(oldBanner);
                    _unitOfWork.Commit();

                    return new ResultMessage
                    {
                        Status = HttpStatusCode.OK,
                        Data = oldBanner.Adapt<BannerDto>()
                    };
                }
                else
                {
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound,
                        ErrorCode = (int)BannersErrorsCodeEnum.NotFoundError
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = (int)BannersErrorsCodeEnum.UpdateError
                };
            }
        }
    }
}
