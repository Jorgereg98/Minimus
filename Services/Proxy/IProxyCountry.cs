using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minimus.Models;

namespace Minimus.Services.Proxy
{
    public interface IProxyCountry
    {
        List<CountryObject> country();
    }
}
