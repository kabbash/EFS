using FluentValidation;
using Mapster;
using Rating.Core.Helpers;
using Rating.Core.Interfaces;
using Rating.Core.Models;
using Shared.Core.Models;
using Shared.Core.Models.Base;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Rating.Core.Services
{
    public class RatingManager<TEntity> : IRatingManager<TEntity> where TEntity : IRateBase
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<RatingDto> _validator;
        private readonly IRepository<TEntity> _ratedEntityRepository;

        public RatingManager(IUnitOfWork unitOfWork, IValidator<RatingDto> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _ratedEntityRepository = _unitOfWork.getRepoByType(typeof(IRepository<TEntity>)) as IRepository<TEntity>;
        }
        public ResultMessage AddOrUpdate(RatingDto ratingDto)
        {
            var validationResult = _validator.Validate(ratingDto);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {
                AddorUpdateRate(ratingDto);
                // To Be Thread
                UpdateOverAllRate(ratingDto);
                return new ResultMessage()
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage()
                {
                    ErrorCode = (int)RatingErrorsCodeEnum.RatingInsertError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        private void AddorUpdateRate(RatingDto ratingDto)
        {
            var oldRating = _unitOfWork.RatingRepository.Get().OldRate(ratingDto).SingleOrDefault();
            if (oldRating != null)
            {
                oldRating.Comment = ratingDto.Comment;
                oldRating.Rate = ratingDto.Rate;
                oldRating.UpdatedAt = DateTime.Now;
                oldRating.UpdatedBy = ratingDto.CurrentUserId;
                _unitOfWork.RatingRepository.Update(oldRating);
            }
            else
            {
                var entityRating = ratingDto.Adapt<EntityRating>();
                entityRating.CreatedAt = DateTime.Now;
                entityRating.CreatedBy = ratingDto.CurrentUserId;
                _unitOfWork.RatingRepository.Insert(entityRating);
            }

            _unitOfWork.Commit();
        }
        private void UpdateOverAllRate(RatingDto ratingDto)
        {
            var entity = _ratedEntityRepository.GetById(ratingDto.EntityId);
            entity.Rate = CalculateRate(ratingDto);
            _ratedEntityRepository.Update(entity);
            _unitOfWork.Commit();
        }
        private decimal CalculateRate(RatingDto ratingDto)
        {
            var rates = _unitOfWork.RatingRepository.Get().AllRates(ratingDto).Select(c => c.Rate).ToList();
            return rates.Count > 0 ? rates.Sum() / rates.Count : 0;
        }
        public List<RatingDto> GetItemRatings(int entityId, RatingEntityTypesEnum ratingEntity)
        {
            var ratingsData = _unitOfWork.RatingRepository.Get().Where(r => r.EntityId == entityId && r.EntityTypeId == (int)ratingEntity).ToList();
            var result = new List<RatingDto>();
            result = ratingsData.Adapt(result);
            return result;
        }
    }
}
