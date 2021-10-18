﻿using Squarfish2.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;

#nullable disable

namespace Squarfish2.DataAccess.Entities
{
    public partial class Person : BaseEntity
    {
        public Person()
        {
            TourLeaders = new HashSet<TourLeader>();
            Users = new HashSet<User>();
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthdate { get; set; }
        public short? Gender { get; set; }

        public virtual ICollection<TourLeader> TourLeaders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
