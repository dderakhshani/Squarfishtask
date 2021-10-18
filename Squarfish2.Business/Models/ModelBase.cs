using AutoMapper;
using Squarfish2.Business.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squarfish2.Business.Models
{
    public abstract class ModelBase<T>: IMapFrom<T>
    {
        public int Id { get; set; }

        public abstract T ToEntity(IMapper mapper);

        public abstract ModelBase<T> FromEntity(T entity,IMapper mapper);
    }
}
