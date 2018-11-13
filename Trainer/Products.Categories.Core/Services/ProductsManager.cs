using FluentValidation;
using Mapster;
using Microsoft.Extensions.Options;
using Products.Core.Interfaces;
using Products.Core.Models;
using Shared.Core;
using Shared.Core.Models;
using Shared.Core.Resources;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;

namespace Products.Core.Services
{
    public class ProductsManager : IProductsManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<ProductsDto> _validator;
        private readonly IOptions<ProductsResources> _productsResources;
        public ProductsManager(IUnitOfWork unitOfWork, IValidator<ProductsDto> validator, IOptions<ProductsResources> productsResources)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _productsResources = productsResources;
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
                    ErrorCode = ErrorsCodeEnum.ProductsGetAllError,
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
                var newProduct = newProductDto.Adapt<Shared.Core.Models.Products>();
                newProduct.CreatedAt = DateTime.Now;
                newProduct.CreatedBy = "7c654344-ad42-4428-a77a-00a8c1299c3f";

                _unitOfWork.ProductsRepository.Insert(newProduct);
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
                    ErrorCode = ErrorsCodeEnum.ProductsInsertError,
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
                        ErrorCode = ErrorsCodeEnum.ProductsNotFoundError
                    };
            }
            catch (Exception ex)
            {
                //log ex
                return new ResultMessage()
                {
                    ErrorCode = ErrorsCodeEnum.ProductsGetByIdError,
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
                        ErrorCode = ErrorsCodeEnum.ProductsNotFoundError
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = ErrorsCodeEnum.ProductsUpdateError
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
                    ErrorCode = ErrorsCodeEnum.ProductsDeleteError
                };
            }
        }       
    }
}
