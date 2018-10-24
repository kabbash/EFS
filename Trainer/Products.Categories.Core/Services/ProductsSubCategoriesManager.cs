using FluentValidation;
using Microsoft.Extensions.Options;
using Products.Core.Models;
using Shared.Core;
using Shared.Core.Models;
using Shared.Core.Resources;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using Mapster;
using Products.Core.Interfaces;
using System.Net;

namespace Products.Core.Services
{
    public class ProductsSubCategoriesManager: IProductsSubCategoriesManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<ProductsSubCategoryDto> _validator;
        private readonly IOptions<ProductsResources> _productsResources;
        public ProductsSubCategoriesManager(IUnitOfWork unitOfWork, IValidator<ProductsSubCategoryDto> validator, IOptions<ProductsResources> productsResources)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _productsResources = productsResources;
        }
        public ResultMessage GetAll()
        {
            try
            {
                IEnumerable<ProductsSubCategoryDto> result = new List<ProductsSubCategoryDto>();
                result = _unitOfWork.ProductsSubCategoriesRepository.Get().Adapt(result);

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
                    ErrorCode = ErrorsCodeEnum.ProductsSubCategoriesGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Insert(ProductsSubCategoryDto category)
        {
            var validationResult = _validator.Validate(category);
            if (!validationResult.IsValid)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };
            }

            try
            {
                _unitOfWork.ProductsSubCategoriesRepository.Insert(category.Adapt<ProductsSubcategories>());
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
                    ErrorCode = ErrorsCodeEnum.ProductsSubCategoriesInsertError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetById(byte id)
        {
            try
            {
                var category = _unitOfWork.ProductsSubCategoriesRepository.GetById(id);
                if (category != null)
                    return new ResultMessage()
                    {
                        Data = category.Adapt<ProductsSubCategoryDto>(),
                        Status = HttpStatusCode.OK
                    };
                else
                    return new ResultMessage()
                    {
                        Status = HttpStatusCode.InternalServerError,
                        ErrorCode = ErrorsCodeEnum.ProductsSubCategoriesNotFoundError
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
        public ResultMessage Update(ProductsSubCategoryDto category, byte id)
        {
            var validationResult = _validator.Validate(category);
            if (!validationResult.IsValid)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };
            }

            try
            {
                var oldCategory = _unitOfWork.ProductsSubCategoriesRepository.GetById(id);
                if (oldCategory != null)
                {
                    oldCategory.Name = category.Name;
                    oldCategory.ProfilePicture = category.ProfilePicture;
                    _unitOfWork.ProductsSubCategoriesRepository.Update(oldCategory);
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
                        ErrorCode = ErrorsCodeEnum.ProductsSubCategoriesNotFoundError
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = ErrorsCodeEnum.ProductsSubCategoriesUpdateError
                };
            }
        }
        public ResultMessage Delete(byte id)
        {
            try
            {
                _unitOfWork.ProductsSubCategoriesRepository.Delete(id);
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
                    ErrorCode = ErrorsCodeEnum.ProductsSubCategoriesDeleteError
                };
            }
        }
    }
}
