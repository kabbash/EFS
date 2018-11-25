using FluentValidation;
using Lookups.Core.Interfaces;
using Mapster;
using Shared.Core;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace Lookups.Core.Services
{
    public class LookupService<DTO, E> : ILookupService<DTO, E > where DTO  : class where E : class
    {
        private readonly IValidator<DTO> _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<E> _repository;
        public LookupService(IValidator<DTO> validator, IUnitOfWork unitOfWork)
        {
            _validator = validator;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.getRepoByType(typeof(IRepository<E>)) as IRepository<E>;
        }
        public ResultMessage GetAll()
        {
            if (_repository == null)
            {
                return new ResultMessage()
                {
                    ErrorCode = (int) ProductsErrorsCodeEnum.ProductsSubCategoriesGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
            try
            {
                IEnumerable<DTO> result = new List<DTO>();
                result = _repository.Get().Adapt(result);

                return new ResultMessage()
                {
                    Data = result.ToList(),
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
        public ResultMessage Insert(DTO lookupDto)
        {
            var validationResult = _validator.Validate(lookupDto);
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
                _repository.Insert(lookupDto.Adapt<E>());
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
                var lookup = _repository.GetById(id);
                if (lookup != null)
                    return new ResultMessage()
                    {
                        Data = lookup.Adapt<DTO>(),
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
        public ResultMessage Update(DTO lookup, int id)
        {
            var validationResult = _validator.Validate(lookup);
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
                var oldLookup = _repository.GetById(id);
                if (oldLookup != null)
                {
                    lookup.Adapt(oldLookup, typeof(DTO), typeof(E));
                    typeof(E).GetProperty("Id").SetValue(oldLookup, id);
            
                    _repository.Update(oldLookup);
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
                _repository.Delete(id);
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
