using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimus.Strategy
{
    public class MailValidation
    {
        private readonly IMailValidation _strategy;
        private readonly string _mail;

        public MailValidation(IMailValidation strategy, string mail)
        {
            _strategy = strategy;
            _mail = mail;
        }

        public bool Verification()
        {
            return _strategy.Verification(_mail);
        }
    }
}
