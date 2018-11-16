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
                    ErrorCode = (int) ProductsErrorsCodeEnum.ProductsSubCategoriesGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Insert(ProductsSubCategoryDto newCategoryDto)
        {
            var validationResult = _validator.Validate(newCategoryDto);
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
                var newCategory = newCategoryDto.Adapt<ProductsSubcategories>();
                newCategory.CreatedAt = DateTime.Now;
                newCategory.CreatedBy = "7c654344-ad42-4428-a77a-00a8c1299c3f";

                _unitOfWork.ProductsSubCategoriesRepository.Insert(newCategory);
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
                    ErrorCode = (int) ProductsErrorsCodeEnum.ProductsSubCategoriesInsertError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetById(int id)
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
                        ErrorCode = (int) ProductsErrorsCodeEnum.ProductsSubCategoriesNotFoundError
                    };
            }
            catch (Exception ex)
            {
                //log ex
                return new ResultMessage()
                {
                    ErrorCode = (int) ProductsErrorsCodeEnum.ProductsGetByIdError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Update(ProductsSubCategoryDto updatedCategoryDto, int id)
        {
            var validationResult = _validator.Validate(updatedCategoryDto);
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
                    oldCategory.Name = updatedCategoryDto.Name;
                    oldCategory.ProfilePicture = updatedCategoryDto.ProfilePicture;
                    oldCategory.UpdatedBy = "7c654344-ad42-4428-a77a-00a8c1299c3f";
                    oldCategory.UpdatedAt = DateTime.Now;

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
                        ErrorCode = (int) ProductsErrorsCodeEnum.ProductsSubCategoriesNotFoundError
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = (int) ProductsErrorsCodeEnum.ProductsSubCategoriesUpdateError
                };
            }
        }
        public ResultMessage Delete(int id)
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
                    ErrorCode = (int) ProductsErrorsCodeEnum.ProductsSubCategoriesDeleteError
                };
            }
        }
    }
}
