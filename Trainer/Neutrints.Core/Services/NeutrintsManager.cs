using Mapster;
using Microsoft.Extensions.Logging;
using Neutrints.Core.Extensions;
using Neutrints.Core.Interfaces;
using Neutrints.Core.Models;
using Shared.Core.Models;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Models;
using System;
using System.Linq;
using System.Net;

namespace Neutrints.Core.Services
{
    public class NeutrintsManager : INeutrintsManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly ILogger<NeutrintsManager> _logger;
        public NeutrintsManager(IUnitOfWork unitOfWork, ILogger<NeutrintsManager> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }
        public ResultMessage GetAll(FoodIemFilter filter = null, string includeProperities = "")
        {
            try
            {
                PagedResult<FoodItemDto> result = new PagedResult<FoodItemDto>();
                result = _unitOfWork.FoodItemsRepository.Get(includeProperties: includeProperities ?? "").ApplyFilter(filter).Where(c => !c.IsDraft).OrderBy(c => c.Id).GetPaged(filter.PageNo, filter.PageSize).Adapt(result);
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
                    ErrorCode = (int)FoodItemsErrorsCodeEnum.GetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Insert(FoodItemDto newFoodItemDto)
        {
            try
            {
                var newFoodItem = newFoodItemDto.Adapt<FoodItem>();
                newFoodItem.CreatedAt = DateTime.Now;
                newFoodItem.CreatedBy = newFoodItemDto.CreatedBy;


                _unitOfWork.FoodItemsRepository.Insert(newFoodItem);
                _unitOfWork.Commit();

                return new ResultMessage
                {
                    Status = HttpStatusCode.OK,
                    Data = GetById(newFoodItem.Id).Data
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage()
                {
                    ErrorCode = (int)FoodItemsErrorsCodeEnum.AddError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetById(int id)
        {
            try
            {
                var foodItem = _unitOfWork.FoodItemsRepository.GetById(id);

                if (foodItem != null &&  ! foodItem.IsDraft)
                {
                    return new ResultMessage()
                    {
                        Data = foodItem.Adapt<FoodItemDto>(),
                        Status = HttpStatusCode.OK
                    };
                }
                else
                {
                    return new ResultMessage()
                    {
                        Status = HttpStatusCode.NotFound,
                        ErrorCode = (int)FoodItemsErrorsCodeEnum.NotFoundError
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage()
                {
                    ErrorCode = (int)FoodItemsErrorsCodeEnum.GetByIdError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Update(FoodItemDto foodItem, int id)
        {
            //var validationResult = _validator.Validate(product);
            //if (!validationResult.IsValid)
            //    return new ResultMessage
            //    {
            //        Status = HttpStatusCode.BadRequest,
            //        ValidationMessages = validationResult.GetErrorsList()
            //    };

            try
            {
                _logger.LogInformation($"START: FOOD.Update: Name:{foodItem.Name}");

                var oldFoodItem = _unitOfWork.FoodItemsRepository.GetById(id);
                if (oldFoodItem != null && ! oldFoodItem.IsDraft)
                {
                    oldFoodItem.Name = foodItem.Name;
                    oldFoodItem.ArabicTxt = foodItem.ArabicTxt;
                    oldFoodItem.Alcohol = foodItem.Alcohol;
                    oldFoodItem.Amount = foodItem.Amount;
                    oldFoodItem.B1 = foodItem.B1;
                    oldFoodItem.B2 = foodItem.B2;
                    oldFoodItem.B12 = foodItem.B12;
                    oldFoodItem.B3 = foodItem.B3;
                    oldFoodItem.B5 = foodItem.B5;
                    oldFoodItem.B6 = foodItem.B6;
                    oldFoodItem.Caffiene = foodItem.Caffiene;
                    oldFoodItem.Calcuim = foodItem.Calcuim;
                    oldFoodItem.Carbs = foodItem.Carbs;
                    oldFoodItem.Cholesterol = foodItem.Cholesterol;
                    oldFoodItem.Copper = foodItem.Copper;
                    oldFoodItem.Cystine = foodItem.Cystine;
                    oldFoodItem.Energy = foodItem.Energy;
                    oldFoodItem.Fat = foodItem.Fat;
                    oldFoodItem.Fiber = foodItem.Fiber;
                    oldFoodItem.Folate = foodItem.Folate;
                    oldFoodItem.Histidine = foodItem.Histidine;
                    oldFoodItem.Iron = foodItem.Iron;
                    oldFoodItem.Isoleucine = foodItem.Isoleucine;
                    oldFoodItem.Leucine = foodItem.Leucine;
                    oldFoodItem.Lysine = foodItem.Lysine;
                    oldFoodItem.Magnesium = foodItem.Magnesium;
                    oldFoodItem.Manganese = foodItem.Manganese;
                    oldFoodItem.Methionine = foodItem.Methionine;
                    oldFoodItem.Monounsaturated = foodItem.Monounsaturated;
                    oldFoodItem.NetCarbs = foodItem.NetCarbs;
                    oldFoodItem.Omega3 = foodItem.Omega3;
                    oldFoodItem.Omega6 = foodItem.Omega6;
                    oldFoodItem.Phenylalanine = foodItem.Phenylalanine;
                    oldFoodItem.Phosphorus = foodItem.Phosphorus;
                    oldFoodItem.Polyunsaturated = foodItem.Polyunsaturated;
                    oldFoodItem.Potassium = foodItem.Potassium;
                    oldFoodItem.Protein = foodItem.Protein;
                    oldFoodItem.Saturated = foodItem.Saturated;
                    oldFoodItem.Selenium = foodItem.Selenium;
                    oldFoodItem.Sodium = foodItem.Sodium;
                    oldFoodItem.Starch = foodItem.Starch;
                    oldFoodItem.Sugars = foodItem.Sugars;
                    oldFoodItem.Threonine = foodItem.Threonine;
                    oldFoodItem.TransFats = foodItem.TransFats;
                    oldFoodItem.Tryptophan = foodItem.Tryptophan;
                    oldFoodItem.Tyrosine = foodItem.Tyrosine;
                    oldFoodItem.Valine = foodItem.Valine;
                    oldFoodItem.VitaminA = foodItem.VitaminA;
                    oldFoodItem.VitaminC = foodItem.VitaminC;
                    oldFoodItem.VitaminD = foodItem.VitaminD;
                    oldFoodItem.VitaminE = foodItem.VitaminE;
                    oldFoodItem.VitaminK = foodItem.VitaminK;
                    oldFoodItem.Water = foodItem.Water;
                    oldFoodItem.Zinc = foodItem.Zinc;

                    oldFoodItem.UpdatedBy = foodItem.UpdatedBy;
                    oldFoodItem.UpdatedAt = DateTime.Now;


                    _unitOfWork.FoodItemsRepository.Update(oldFoodItem);
                    _unitOfWork.Commit();

                    _logger.LogInformation($"END: FOOD.Update: Name:{foodItem.Name} --SUCCESS");

                    return new ResultMessage
                    {
                        Status = HttpStatusCode.OK,
                        Data = oldFoodItem.Adapt<FoodItemDto>()
                    };
                }
                else
                {
                    _logger.LogInformation($"END: FOOD.Update: Name:{foodItem.Name} --NOTFOUND");

                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound,
                        ErrorCode = (int)FoodItemsErrorsCodeEnum.NotFoundError
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = (int)FoodItemsErrorsCodeEnum.UpdateError
                };
            }
        }
        public ResultMessage Delete(int id)
        {
            try
            {
                _logger.LogInformation($"START: FOOD.Delete: ID:{id}");

                var oldFoodItem = _unitOfWork.FoodItemsRepository.GetById(id);
                if (oldFoodItem == null || oldFoodItem.IsDraft)
                {
                    _logger.LogInformation($"END: FOOD.Delete: ID:{id} --NOTFOUND");

                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound

                    };
                }

                oldFoodItem.IsDraft = true;
                oldFoodItem.UpdatedAt = DateTime.Now;
                _unitOfWork.FoodItemsRepository.Update(oldFoodItem);
                _unitOfWork.Commit();

                _logger.LogInformation($"END: FOOD.Delete: ID:{id} --SUCCESS");

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
                    ErrorCode = (int)FoodItemsErrorsCodeEnum.DeleteError
                };
            }
        }
    }
}
