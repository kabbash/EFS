using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.Options;
using Products.Core.Interfaces;
using Products.Core.Models;
using Shared.Core;
using Shared.Core.Resources;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Net;

namespace Products.Core.Services
{
    public class ProductsManager : IProductsManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<ProductsDto> _validator;
        private readonly IOptions<ProductsResources> _productsResources;
        private readonly IAttachmentsManager _attachmentsManager;

        public ProductsManager(IUnitOfWork unitOfWork, IValidator<ProductsDto> validator, IOptions<ProductsResources> productsResources, IAttachmentsManager attachmentsManager)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _productsResources = productsResources;
            _attachmentsManager = attachmentsManager;
        }
        public ResultMessage GetAll()
        {
            try
            {
                IEnumerable<ProductsDto> result = new List<ProductsDto>();
                result = _unitOfWork.ProductsRepository.Get().Adapt(result);

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
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Insert(ProductsDto newProductDto)
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
                var newProduct = newProductDto.Adapt<Shared.Core.Models.Products>();
                newProduct.CreatedAt = DateTime.Now;
                newProduct.CreatedBy = "7c654344-ad42-4428-a77a-00a8c1299c3f";
                newProduct.ProfilePicture = _attachmentsManager.Save(new SavedFileDto
                {
                    attachmentType = AttachmentTypesEnum.Products,
                    CanChangeName = false,
                    File = newProductDto.ProfilePictureFile,
                    SubFolderName = productFolderName,
                });

                foreach (var image in newProductDto.ProductsImagesFiles)
                {
                    newProduct.ProductsImages.Add(new Shared.Core.Models.ProductsImages()
                    {
                        Name = image.Name,
                        ProductId = newProduct.Id,
                        Path = _attachmentsManager.Save(new SavedFileDto
                        {
                            attachmentType= AttachmentTypesEnum.Products,
                            CanChangeName = false,
                            File = image,
                            SubFolderName = productFolderName
                        })
                    });
                }

                _unitOfWork.ProductsRepository.Insert(newProduct);
                _unitOfWork.Commit();
                return new ResultMessage
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
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
                    return new ResultMessage()
                    {
                        Data = product.Adapt<ProductsDto>(),
                        Status = HttpStatusCode.OK
                    };
                else
                    return new ResultMessage()
                    {
                        Status = HttpStatusCode.NotFound,
                        ErrorCode = (int)ProductsErrorsCodeEnum.ProductsNotFoundError
                    };
            }
            catch (Exception ex)
            {
                //log ex
                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsGetByIdError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Update(ProductsDto product, int id)
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
                if (oldProduct != null)
                {
                    oldProduct.Name = product.Name;
                    oldProduct.ProfilePicture = product.ProfilePicture;
                    oldProduct.UpdatedBy = "7c654344-ad42-4428-a77a-00a8c1299c3f";
                    oldProduct.UpdatedAt = DateTime.Now;

                    _unitOfWork.ProductsRepository.Update(oldProduct);
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
                        ErrorCode = (int)ProductsErrorsCodeEnum.ProductsNotFoundError
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsUpdateError
                };
            }
        }
        public ResultMessage Delete(int id)
        {
            try
            {
                _unitOfWork.ProductsRepository.Delete(id);
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
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsDeleteError
                };
            }
        }
        public ResultMessage GetByCategoryId(int categoryId)
        {
            try
            {
                IEnumerable<ProductsDto> result = new List<ProductsDto>();
                result = _unitOfWork.ProductsRepository.Get(c => c.CategoryId == categoryId).Adapt(result);

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
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
