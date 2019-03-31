using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using FluentValidation;
using Mapster;
using OTraining.Core.Interfaces;
using OTraining.Core.Models;
using Shared.Core.Models;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace OTraining.Core.Services
{
    public class OTrainingManager : IOTrainingManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IAttachmentsManager _attachmentsManager;
        private readonly IValidator<OTrainingDetailsDto> _detailsValidator;
        private readonly IValidator<OTrainingProgramDto> _programValidator;

        public OTrainingManager(IUnitOfWork unitOfWork, IValidator<OTrainingDetailsDto> detailsValidator, IValidator<OTrainingProgramDto> programValidator, IAttachmentsManager attachmentsManager)
        {
            _unitOfWork = unitOfWork;
            _programValidator = programValidator;
            _detailsValidator = detailsValidator;
            _attachmentsManager = attachmentsManager;
        }

        public ResultMessage GetAll()
        {
            try
            {
                var dto = new OTrainingDto();
                var trainingDetails = _unitOfWork.ConfigurationsRepository.Get(c => c.Type == (int)ConfigurationsEnum.OTrainingDetails
                || c.Type == (int)ConfigurationsEnum.OTrainingForJoin);

                dto.DetailsDto.Description = trainingDetails.FirstOrDefault(c => c.Type == (int)ConfigurationsEnum.OTrainingDetails)?.Value ?? "";
                dto.DetailsDto.ForJoin = trainingDetails.FirstOrDefault(c => c.Type == (int)ConfigurationsEnum.OTrainingForJoin)?.Value ?? "";
                dto.ProgramsDto = _unitOfWork.OTrainingProgramsRepository.Get().Select(c => new OTrainingProgramDto
                {
                    Name = c.Name,
                    Features = c.Features
                }).ToList();

                return new ResultMessage
                {
                    Data = dto,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage()
                {
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }

        public ResultMessage GetProgramById(int id)
        {
            try
            {
                var program = _unitOfWork.OTrainingProgramsRepository.GetById(id);
                if (program != null)
                {
                    var programDto = program.Adapt<OTrainingProgramDto>();
                    return new ResultMessage()
                    {
                        Data = programDto,
                        Status = HttpStatusCode.OK
                    };
                }
                else
                    return new ResultMessage()
                    {
                        Status = HttpStatusCode.NotFound
                    };
            }
            catch (Exception ex)
            {
                return new ResultMessage()
                {
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }

        public ResultMessage InsertProgram(OTrainingProgramDto programDto, IUserDto user)
        {
            var validationResult = _programValidator.Validate(programDto);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {
                var newProgram = programDto.Adapt<OTrainingPrograms>();
                newProgram.CreatedAt = DateTime.Now;
                newProgram.CreatedBy = user.Id;
                newProgram.ProfilePicture = _attachmentsManager.Save(new SavedFileDto
                {
                    File = programDto.ProfilePictureFile,
                    attachmentType = AttachmentTypesEnum.OTrainingProgram,
                    CanChangeName = true
                });

                _unitOfWork.OTrainingProgramsRepository.Insert(newProgram);
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
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }

        public ResultMessage UpdateDetails(OTrainingDetailsDto detailsDto)
        {
            var validationResult = _detailsValidator.Validate(detailsDto);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {

                var descriptionRow = _unitOfWork.ConfigurationsRepository.Get(c => c.Type == (int)ConfigurationsEnum.OTrainingDetails).FirstOrDefault();
                if (descriptionRow == null)
                {
                    _unitOfWork.ConfigurationsRepository.Insert(new Configurations
                    {
                        Type = (int)ConfigurationsEnum.OTrainingDetails,
                        Value = detailsDto.Description
                    });
                }
                else
                {
                    descriptionRow.Value = detailsDto.Description;
                    _unitOfWork.ConfigurationsRepository.Update(descriptionRow);
                }

                var forJoinRow = _unitOfWork.ConfigurationsRepository.Get(c => c.Type == (int)ConfigurationsEnum.OTrainingForJoin).FirstOrDefault();
                if (forJoinRow == null)
                {
                    _unitOfWork.ConfigurationsRepository.Insert(new Configurations
                    {
                        Type = (int)ConfigurationsEnum.OTrainingForJoin,
                        Value = detailsDto.ForJoin
                    });
                }
                else
                {
                    forJoinRow.Value = detailsDto.ForJoin;
                    _unitOfWork.ConfigurationsRepository.Update(forJoinRow);
                }

                _unitOfWork.Commit();
                return new ResultMessage
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }

        public ResultMessage UpdateProgram(OTrainingProgramDto programDto, int id, IUserDto user)
        {
            var validationResult = _programValidator.Validate(programDto);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {
                var program = _unitOfWork.OTrainingProgramsRepository.GetById(id);
                if (program != null)
                {
                    program.Name = programDto.Name;
                    program.Features = programDto.Features;
                    program.UpdatedBy = user.Id;
                    program.UpdatedAt = DateTime.Now;

                    if (programDto.ProfilePictureFile != null && programDto.ProfilePictureFile.Length > 0)
                        program.ProfilePicture = _attachmentsManager.Save(new SavedFileDto
                        {
                            File = programDto.ProfilePictureFile,
                            attachmentType = AttachmentTypesEnum.OTrainingProgram,
                            CanChangeName = true
                        });

                    _unitOfWork.OTrainingProgramsRepository.Update(program);
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
                        ErrorCode = (int)ProductsErrorsCodeEnum.ProductsCategoriesNotFoundError
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsCategoriesUpdateError
                };
            }
        }

        public ResultMessage DeleteProgram(int id, IUserDto user)
        {
            try
            {
                var program = _unitOfWork.OTrainingProgramsRepository.GetById(id);
                if (program == null)
                {
                    return new ResultMessage()
                    {
                        Status = HttpStatusCode.NotFound
                    };
                }
                _unitOfWork.OTrainingProgramsRepository.Delete(id);
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
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
