using AutoMapper;
using Squarfish2.Business.Mappings;
using Squarfish2.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squarfish2.Business.Models
{
    public class LeaderModel : ModelBase<Leader>
    {
        public int PersonId { get; set; }
        public int TourId { get; set; }
        public short ExprienceYears { get; set; }

        public string FullName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthdate { get; set; }
        public short? Gender { get; set; }

        #region Mappings
        public void Mapping(Profile profile)
        {

            profile.CreateMap<LeaderModel, Leader>()
                .IgnoreAllNonExisting();

            profile.CreateMap<Leader, LeaderModel>()
               . ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(x => x.FullName, opt => opt.MapFrom(src => src.Person.Firstname + " " + src.Person.Lastname))
                .ForMember(x => x.Firstname, opt => opt.MapFrom(src => src.Person.Firstname))
                 .ForMember(x => x.Lastname, opt => opt.MapFrom(src => src.Person.Lastname))
                  .ForMember(x => x.Gender, opt => opt.MapFrom(src => src.Person.Gender))
                   .ForMember(x => x.Birthdate, opt => opt.MapFrom(src => src.Person.Birthdate));
        }

        public override ModelBase<Leader> FromEntity(Leader entity, IMapper mapper)
        {
            return mapper.Map<ModelBase<Leader>>(entity);
        }

        public override Leader ToEntity(IMapper mapper)
        {
            return mapper.Map<Leader>(this);
        }

        #endregion
    }
}
