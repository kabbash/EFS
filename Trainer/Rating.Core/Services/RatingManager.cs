using FluentValidation;
using Mapster;
using Microsoft.Extensions.Options;
using Shared.Core;
using Shared.Core.Models;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;
using Rating.Core.Interfaces;
using Rating.Core.Models;
using Rating.Core.Helpers;

namespace Rating.Core.Services
{
    public class RatingManager<TEntity> : IRatingManager<TEntity>  where TEntity : IRateBase
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<RatingDto> _validator;
        private readonly IRepository<TEntity> _ratedEntityRepository;
        private readonly int _x;

        public RatingManager(int x ,IUnitOfWork unitOfWork, IValidator<RatingDto> validator)
        {
            _x = x;
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
                    ErrorCode =(int) RatingErrorsCodeEnum.RatingInsertError,
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
                _unitOfWork.RatingRepository.Update(oldRating);
            }
            else
                _unitOfWork.RatingRepository.Insert(ratingDto.Adapt<EntityRating>());

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
    }
}
