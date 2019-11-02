using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimus.Strategy
{
    public interface IMailValidation
    {
        bool Verification(string mail);
    }
}
