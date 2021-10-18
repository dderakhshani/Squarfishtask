using Squarfish2.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;

#nullable disable

namespace Squarfish2.DataAccess.Entities
{
    public partial class Booking:BaseEntity
    {
        public int TourId { get; set; }
        public int BookerUserId { get; set; }
        public short Status { get; set; }

        public virtual User BookerUser { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
