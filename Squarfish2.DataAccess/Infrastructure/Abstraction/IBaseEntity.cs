using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squarfish2.DataAccess.Infrastructure
{
    public interface IBaseEntity
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the CreatorUserId
        /// </summary>
        public int CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the addedDate
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the modifiedDate
        /// </summary>
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modifiedDate
        /// </summary>
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the isDeleted
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
