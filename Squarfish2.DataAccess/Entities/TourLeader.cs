using Squarfish2.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;

#nullable disable

namespace Squarfish2.DataAccess.Entities
{
    public partial class TourLeader: BaseEntity
    {
        public int LeaderId { get; set; }
        public int TourId { get; set; }


        public virtual Leader Leader { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
