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
    public class LeaderService : ILeaderService
    {
        private readonly IRepository<Leader> _repository;
        private readonly IMapper _mapper;

        public LeaderService(IRepository<Leader> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task<LeaderModel> Add(LeaderModel tourModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Cancel(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LeaderModel>> GetAll()
        {
            var data = await _repository.GetAll()
                .Include(x=>x.Person)
                .ProjectTo<LeaderModel>(_mapper.ConfigurationProvider)
               .ToListAsync();
            return data;
        }

        public Task Update(TourModel tourModel)
        {
            throw new NotImplementedException();
        }
    }
}
