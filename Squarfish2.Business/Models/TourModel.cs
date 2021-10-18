using AutoMapper;
using Squarfish2.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Squarfish2.Business.Mappings;

namespace Squarfish2.Business.Models
{
    public class TourModel:ModelBase<Tour>
    {

        public TourModel()
        {
        }

        public string TourTitle { get; set; }
        public DateTime? StartTime { get; set; }
        public TourStatus Status { get; set; }//Consider Enum can be in Entity with ValueConversions
        public double? Price { get; set; }
        public CurrencyUnits CurrencyUnit { get; set; }//Consider Enum can be in Entity with ValueConversions

        public List<int> TourLeaderIds { get; set; }

        public ICollection<LeaderModel> Leaders { get; set; }

        #region Mappings
        public void Mapping(Profile profile)
        {

            profile.CreateMap<TourModel, Tour>()
                 .ForMember(m => m.Status, opt => opt.MapFrom(src => (short)src.Status))
                 .ForMember(m => m.CurrencyUnit, opt => opt.MapFrom(src => (short)src.CurrencyUnit))
                .IgnoreAllNonExisting();

            profile.CreateMap<Tour, TourModel>()
                .ForMember(m => m.Status, opt => opt.MapFrom(src => (TourStatus)(src.Status)))
                 .ForMember(m => m.CurrencyUnit, opt => opt.MapFrom(src => (CurrencyUnits)(src.CurrencyUnit)))
                ;
        }

        public override ModelBase<Tour> FromEntity(Tour entity, IMapper mapper)
        {
            return mapper.Map<ModelBase<Tour>>(entity);
        }

        public override Tour ToEntity(IMapper mapper)
        {
            return mapper.Map<Tour>(this);
        }

        public static TourModel DefaultSearchFilters()
        {
            return new TourModel() { TourTitle = "", Status = TourStatus.NoValue };
        }

        #endregion
    }
}
