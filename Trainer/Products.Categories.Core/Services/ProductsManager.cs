using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.Logging;
using Products.Core.Extensions;
using Products.Core.Interfaces;
using Products.Core.Models;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DBModels = Shared.Core.Models;

namespace Products.Core.Services
{
    public class ProductsManager : IProductsManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<ProductsDto> _validator;
        private readonly IAttachmentsManager _attachmentsManager;
        private readonly ISliderManager<DBModels.ProductsImages> _sliderManager;
        private readonly ILogger<ProductsManager> _logger;


        public ProductsManager(IUnitOfWork unitOfWork, IValidator<ProductsDto> validator, IAttachmentsManager attachmentsManager, ISliderManager<DBModels.ProductsImages> sliderManager, ILogger<ProductsManager> logger)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _attachmentsManager = attachmentsManager;
            _sliderManager = sliderManager;
            _logger = logger;
        }
        public ResultMessage GetAll(ProductFilter filter = null, string includeProperities = "")
        {
            try
            {
                PagedResult<ProductsDto> result = new PagedResult<ProductsDto>();
                result = _unitOfWork.ProductsRepository.Get(includeProperties: includeProperities ?? "").OrderByDescending(c => c.CreatedAt).ApplyFilter(filter).GetPaged(filter.PageNo, filter.PageSize).Adapt(result);
                return new ResultMessage()
                {
                    Data = result,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Insert(ProductsDto newProductDto, IUserDto user)
        {
            var validationResult = _validator.Validate(newProductDto);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {
                var productFolderName = Guid.NewGuid().ToString();
                var newProduct = newProductDto.Adapt<DBModels.Products>();
                newProduct.IsActive = null;
                newProduct.CreatedAt = DateTime.Now;
                newProduct.CreatedBy = user.Id;
                newProduct.SubFolderName = productFolderName;

                var sliderDto = new SliderDto
                {
                    attachmentType = AttachmentTypesEnum.Products,
                    Items = newProductDto.UpdatedImages,
                    SubFolderName = productFolderName
                };

                if (sliderDto.Items != null && sliderDto.Items.Count > 0)
                    newProduct.ProfilePicture = _sliderManager.GetProfilePicturePath(sliderDto);

                if (user.IsAdmin)
                    newProduct.IsActive = true;

                _unitOfWork.ProductsRepository.Insert(newProduct);
                _unitOfWork.Commit();

                sliderDto.ParentId = newProduct.Id;
                _sliderManager.Add(sliderDto);

                return new ResultMessage
                {
                    Status = HttpStatusCode.OK,
                    Data = GetById(newProduct.Id).Data
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsInsertError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetById(int id)
        {
            try
            {
                var product = _unitOfWork.ProductsRepository.GetById(id);


                if (product != null)
                {
                    var productDto = product.Adapt<ProductsDto>();

                    if (product.Images != null)
                        productDto.Images = product.Images.Select(c => new SliderItemDto
                        {
                            Path = c.Path,
                            Id = c.Id,
                            IsProfilePicture = c.Path == product.ProfilePicture
                        }).ToList();

                    return new ResultMessage()
                    {
                        Data = productDto,
                        Status = HttpStatusCode.OK
                    };
                }
                else
                    return new ResultMessage()
                    {
                        Status = HttpStatusCode.NotFound,
                        ErrorCode = (int)ProductsErrorsCodeEnum.ProductsNotFoundError
                    };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsGetByIdError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Update(ProductsDto product, int id, IUserDto user)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {
                var oldProduct = _unitOfWork.ProductsRepository.GetById(id);
                if (oldProduct == null)
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound,
                        ErrorCode = (int)ProductsErrorsCodeEnum.ProductsNotFoundError
                    };

                if (!user.IsAdmin && oldProduct.CreatedBy != user.Id)
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound,
                        ErrorCode = (int)ProductsErrorsCodeEnum.ProductsNotFoundError
                    };

                oldProduct.Name = product.Name;
                if (product.ProfilePictureFile != null)
                {
                    oldProduct.ProfilePicture = _attachmentsManager.Save(new SavedFileDto
                    {
                        attachmentType = AttachmentTypesEnum.Products,
                        CanChangeName = true,
                        File = product.ProfilePictureFile
                    });
                }

                oldProduct.IsActive = product.IsActive = null;
                if (user.IsAdmin)
                    oldProduct.IsActive = true;

                oldProduct.IsSpecial = product.IsSpecial;
                oldProduct.Price = product.Price;
                oldProduct.ExpDate = product.ExpDate;
                oldProduct.Description = product.Description;
                oldProduct.CategoryId = product.CategoryId;
                oldProduct.PhoneNumber = product.PhoneNumber;

                oldProduct.UpdatedBy = user.Id;
                oldProduct.UpdatedAt = DateTime.Now;

                var sliderDto = new SliderDto
                {
                    attachmentType = AttachmentTypesEnum.Products,
                    Items = product.UpdatedImages ?? new List<SliderItemDto>(),
                    SubFolderName = oldProduct.SubFolderName,
                    ParentId = id
                };

                //check profile picture
                if (sliderDto.Items.Count > 0)
                    oldProduct.ProfilePicture = _sliderManager.GetProfilePicturePath(sliderDto, oldProduct.ProfilePicture);


                _unitOfWork.ProductsRepository.Update(oldProduct);
                _unitOfWork.Commit();

                // update files                
                if (sliderDto.Items.Count > 0)
                    _sliderManager.Update(sliderDto);

                return new ResultMessage
                {
                    Status = HttpStatusCode.OK,
                    Data = oldProduct.Adapt<ProductsDto>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsUpdateError
                };
            }
        }
        public ResultMessage Delete(int id, IUserDto user)
        {
            try
            {
                var product = _unitOfWork.ProductsRepository.GetById(id);
                if (product == null)
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound
                    };

                if (!user.IsAdmin && product.CreatedBy != user.Id)
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.Unauthorized,
                        ErrorCode = (int)ProductsErrorsCodeEnum.ProductsNotFoundError
                    };

                //delete attachments 
                var productFolder = product.SubFolderName;
                if (!string.IsNullOrEmpty(productFolder))
                    _attachmentsManager.DeleteFolder(productFolder, AttachmentTypesEnum.Products);


                _unitOfWork.ProductsRepository.Delete(id);
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
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsDeleteError
                };
            }
        }

        public ResultMessage Approve(int id)
        {

            try
            {
                var product = _unitOfWork.ProductsRepository.GetById(id);
                if (product == null)
                {
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.BadRequest,
                    };
                }

                product.UpdatedAt = DateTime.Now;
                product.IsActive = true;
                //articleData.UpdatedBy = userId;
                _unitOfWork.ProductsRepository.Update(product);
                _unitOfWork.Commit();
                return new ResultMessage
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError
                };

            }
        }
        public ResultMessage Reject(RejectDto rejectModel, IUserDto user)
        {

            try
            {
                var product = _unitOfWork.ProductsRepository.GetById(rejectModel.Id);
                if (product == null)
                {
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.BadRequest,
                    };
                }

                product.UpdatedAt = DateTime.Now;
                product.IsActive = false;
                product.RejectReason = rejectModel.RejectReason;
                product.UpdatedBy = user.Id;

                _unitOfWork.ProductsRepository.Update(product);
                _unitOfWork.Commit();
                return new ResultMessage
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
