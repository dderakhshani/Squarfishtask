using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squarfish2.DataAccess.Infrastructure.Exceptions
{
    public class EntityNullException : System.Exception
    {
        public EntityNullException(string message = "Entity can not be null")
            : base(message)
        {
        }
    }

    public class EntityNotFountException : System.Exception
    {
        public EntityNotFountException(string message = "Entity not found")
            : base(message)
        {
        }
    }
}
