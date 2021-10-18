using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squarfish2.Business.Models
{
    public enum TourStatus
    {
        NoValue = -1,
        Created =1,
        Confirmed=2,
        Canceled=3
    }

    public enum CurrencyUnits
    {
        Dollar = 1,
        Euro = 2,
        BitCoin = 3
    }
}
