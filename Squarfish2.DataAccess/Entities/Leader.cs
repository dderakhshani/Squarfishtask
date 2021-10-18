using Squarfish2.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;

#nullable disable

namespace Squarfish2.DataAccess.Entities
{
    public partial class Leader:BaseEntity
    {
        public Leader()
        {
            TourLeaders = new HashSet<TourLeader>();
        }

        public int PersonId { get; set; }
        public int TourId { get; set; }
        public short ExprienceYears { get; set; }

        public virtual Person Person { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual ICollection<TourLeader> TourLeaders { get; set; }
    }
}
