using meetroomreservation.Business.Exceptions;
using meetroomreservation.Business.Mapper.Interfaces;
using meetroomreservation.Business.Services.Interfaces;
using meetroomreservation.Business.Validations;
using meetroomreservation.Data.ApplicationModels;
using meetroomreservation.Data.Dao.Interfaces;
using meetroomreservation.Data.Models;
using meetroomreservation.Data.Repositories.Interfaces;
using meetroomreservation.Data.RequestModel;
using Microsoft.EntityFrameworkCore;

namespace meetroomreservation.Business.Services
{
    public class SchedulingService : ISchedulingService
    {
        #region Variables
        private readonly ISchedulingCreateMapper _schedulingCreateMapper;
        private readonly ISchedulingUpdateMapper _schedulingUpdateMapper;
        private readonly ISchedulingRepository _schedulingRepository;
        private readonly ISchedulingDb _schedulingDb;
        #endregion

        #region Constructor
        public SchedulingService(
            ISchedulingCreateMapper schedulingCreateMapper,
            ISchedulingRepository schedulingRepository,
            ISchedulingUpdateMapper schedulingUpdateMapper,
            ISchedulingDb schedulingDb
        )
        {
            _schedulingCreateMapper = schedulingCreateMapper;
            _schedulingRepository = schedulingRepository;
            _schedulingUpdateMapper = schedulingUpdateMapper;
            _schedulingDb = schedulingDb;

        }
        #endregion
        #region Methods
        /// <summary>
        /// Criando agendamento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="CustomValidationException"></exception> <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
         public Task<int> CreateScheduling(SchedulingCreateRequest request)
        {
            Scheduling scheduling;
            SchedulingCreateValidation validation;
            Dictionary<string, string> errors;

            _schedulingCreateMapper.SetBaseMapping(request);
            validation = new SchedulingCreateValidation();
            if (!validation.IsValid(request))
            {
                errors = validation.GetErrors();
                throw new CustomValidationException(errors);
            }
            try
            {
                scheduling = _schedulingCreateMapper.GetScheduling();
                _schedulingRepository.Create(scheduling);
                return Task.FromResult(scheduling.Id);
            }
            catch (DbUpdateException exception)
            {
                errors = validation.GetPersistenceErrors(exception);
                if (errors.Count == 0)
                {
                    throw;
                }
                throw new CustomValidationException(errors);
            }
        }
        
        /// <summary>
        /// alterando agendamento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="CustomValidationException"></exception> <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<bool> UpdateScheduling (SchedulingUpdateRequestModel request)
        {
            Scheduling scheduling;
            SchedulingUpdateValidation validation;
            Dictionary<string, string> errors;

            _schedulingUpdateMapper.SetBaseMapping(request);
            validation = new SchedulingUpdateValidation();
            if (!validation.IsValid(request))
            {
                errors = validation.GetErrors();
                throw new CustomValidationException(errors);
            }
            try
            {
                scheduling = _schedulingUpdateMapper.GetScheduling();
                _schedulingRepository.Update(scheduling);
                return Task.FromResult(true);
            }
            catch (DbUpdateException exception)
            {
                errors = validation.GetPersistenceErrors(exception);
                if (errors.Count == 0)
                {
                    throw;
                }
                throw new CustomValidationException(errors);
            }
        }

        public async Task<PaginatedList<SchedulingResponseModel>> GetPaginatedListSchedulingByUserId (int userId, int page, int perPage, Pagination pagination)
        {
            PaginatedList<SchedulingResponseModel> schedulingList;
            schedulingList = await _schedulingDb.GetPaginatedListSchedulingByUserId(userId,page, perPage, pagination);

           if (PaginatedList<SchedulingResponseModel>.IsEmpty(schedulingList))
            {
                throw new RecordNotFoundException();
            }

            return schedulingList;
        }

        public async Task<bool> DeleteSchedulingByUserId(int id)
        {
            bool success;
            Dictionary<string,string> errors;
            SchedulingDeleteValidation validation;
            validation = new SchedulingDeleteValidation();
            try
            {
                success = await _schedulingRepository.Delete(id);
                return success;
            }
            catch (DbUpdateException exception)
            {
                errors = validation.GetPersistenceErrors(exception);
                throw new CustomValidationException(errors);
            }
        }
        #endregion
    }
}