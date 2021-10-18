using Squarfish2.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;

#nullable disable

namespace Squarfish2.DataAccess.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public string Username { get; set; }
        public byte[] Password { get; set; }
        public string Email { get; set; }
        public int PersonId { get; set; }
      

        public virtual Person Person { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
