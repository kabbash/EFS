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
using System.Net;

namespace Products.Core.Services
{
    public class ProductsCategoriesManager : IProductsCategoriesManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<ProductsCategoryDto> _validator;
        private readonly IOptions<ProductsResources> _productsResources;
        public ProductsCategoriesManager(IUnitOfWork unitOfWork, IValidator<ProductsCategoryDto> validator, IOptions<ProductsResources> productsResources)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _productsResources = productsResources;
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
                    ErrorCode = ErrorsCodeEnum.ProductsCategoriesGetAllError,
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
                _unitOfWork.ProductsCategoriesRepository.Insert(category.Adapt<ProductsCategories>());                
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
                    ErrorCode = ErrorsCodeEnum.ProductsCategoriesInsertError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetById(byte id)
        {
            try
            {
                var category = _unitOfWork.ProductsCategoriesRepository.GetById(id);
                if(category !=null)
                return new ResultMessage()
                {
                    Data = category.Adapt<ProductsCategoryDto>(),
                    Status = HttpStatusCode.OK
                };
                else
                    return new ResultMessage()
                    {                        
                        Status = HttpStatusCode.NotFound,
                        ErrorCode = ErrorsCodeEnum.ProductsCategoriesNotFoundError
                    };
            }
            catch (Exception ex)
            {
                //log ex
                return new ResultMessage()
                {
                    ErrorCode =ErrorsCodeEnum.ProductsCategoriesGetByIdError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Update(ProductsCategoryDto category, byte id)
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
                        ErrorCode = ErrorsCodeEnum.ProductsCategoriesNotFoundError
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = ErrorsCodeEnum.ProductsCategoriesUpdateError
                };
            }
        }
        public ResultMessage Delete(byte id)
        {
            try
            {
                _unitOfWork.ProductsCategoriesRepository.Delete(id);
                _unitOfWork.Commit();
                return new ResultMessage ()
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = ErrorsCodeEnum.ProductsCategoriesDeleteError
                };
            }
        }
    }
}
