using Squarfish2.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squarfish2.Business.Abstraction
{
    public interface ITourService: IService
    {


        Task<TourModel> Add(TourModel tourModel);


        Task<bool> Delete(int Id);

        Task Update(TourModel tourModel);

        Task<IEnumerable<TourModel>> GetTours(TourModel searchFilter);

        Task<bool> Confirm(int Id);

        Task<bool> Cancel(int Id);
    }
}
