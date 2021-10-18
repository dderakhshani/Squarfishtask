using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squarfish2.DataAccess.Infrastructure
{
    public interface ICurrentUserAccessor
    {
        public int GetId();

        public string GetIp();
        public string GetUsername();
    }
}
