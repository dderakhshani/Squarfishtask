using Squarfish2.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squarfish2.Business.Abstraction
{
    public interface ILeaderService : IService
    {

        Task<LeaderModel> Add(LeaderModel tourModel);

        Task<bool> Cancel(int Id);

        Task<bool> Delete(int Id);

        Task Update(TourModel tourModel);

        Task<IEnumerable<LeaderModel>> GetAll();
    }
}
