using Squarfish2.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squarfish2.WebApi.Models
{
    public class CurrentUserAccessor : ICurrentUserAccessor
    {
        public int GetId()
        {
            //for test purpose return static data unless it should be read from Claims:
            //_httpContextAccessor.HttpContext.User?.Claims?
            return 1; 
        }

        public string GetIp()
        {
            throw new NotImplementedException();
        }

        public string GetUsername()
        {
            throw new NotImplementedException();
        }
    }
}
