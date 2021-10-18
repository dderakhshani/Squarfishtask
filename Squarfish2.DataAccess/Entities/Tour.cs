﻿using Squarfish2.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;

#nullable disable

namespace Squarfish2.DataAccess.Entities
{
    public partial class Tour: BaseEntity
    {
        public Tour()
        {
            Bookings = new HashSet<Booking>();
            Leaders = new HashSet<Leader>();
            TourLeaders = new HashSet<TourLeader>();
        }

        public string TourTitle { get; set; }
        public DateTime? StartTime { get; set; }
        public short Status { get; set; }
        public double? Price { get; set; }
        public short? CurrencyUnit { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Leader> Leaders { get; set; }
        public virtual ICollection<TourLeader> TourLeaders { get; set; }
    }
}
