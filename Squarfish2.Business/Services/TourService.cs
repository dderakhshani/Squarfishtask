using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Squarfish2.Business.Abstraction;
using Squarfish2.Business.Models;
using Squarfish2.DataAccess.Entities;
using Squarfish2.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squarfish2.Business.Services
{
    public class TourService : ITourService
    {
        private readonly IRepository<Tour> _repository;
        private readonly IRepository<TourLeader> _repositoryTourLeader;
        private readonly IMapper _mapper;

        public TourService(IRepository<Tour> repository, IRepository<TourLeader> repositoryTourLeader, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryTourLeader = repositoryTourLeader;
        }

        public async Task<TourModel> Add(TourModel tourModel)
        {
            var entity = tourModel.ToEntity(_mapper);
            entity.Status = (short)TourStatus.Created;
            _repository.Add(entity);

            foreach (var id in tourModel.TourLeaderIds)
                _repositoryTourLeader.Add(new TourLeader
                {
                    Tour = entity,
                    LeaderId = id
                });

            await _repository.SaveChangesAsync();
            tourModel.Id = entity.Id;
            return tourModel;
            //return (TourModel)tourModel.FromEntity(entity, _mapper);// for some bug commented
        }

        public async Task<bool> Cancel(int Id)
        {
            var entity = await _repository.FindById(Id);
            if (entity.Status != (short)TourStatus.Confirmed)
                return false;

            entity.Status = (short)TourStatus.Canceled;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Confirm(int Id)
        {
            var entity = await _repository.FindById(Id);
            if (entity.Status > (short)TourStatus.Created)
                return false;

            entity.Status = (short)TourStatus.Confirmed;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int Id)
        {
            var entity = await _repository.FindById(Id);
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TourModel>> GetTours(TourModel searchFilter)
        {
            var status = (short)searchFilter.Status;
            //This is not correct way to apply Search condition
            //Search should be apply by QueryBuilder and ignore default value automatically
            var data = await _repository.GetAll()
                 .Where(x => x.TourTitle == searchFilter.TourTitle || searchFilter.TourTitle == "")
                 .Where(x => x.Status == status || status == -1)
                 .Include(x => x.Leaders)
                 .ProjectTo<TourModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return data;
        }

        public async Task Update(TourModel tourModel)
        {
            var entity = await _repository.FindById(tourModel.Id);
            entity = tourModel.ToEntity(_mapper);

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }
    }
}
