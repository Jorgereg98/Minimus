using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minimus.Models;

namespace Minimus
{
    public class PasswordFluentBuilder
    {
        private readonly Password _password;

        public static PasswordFluentBuilder Create(DifficultyEnum difficulty)
        {
            return new PasswordFluentBuilder(difficulty);
        }

        private PasswordFluentBuilder(DifficultyEnum difficulty)
        {
            _password = new Password { Difficulty = difficulty };
        }

        public Password Finish()
        {
            return _password;
        }
    }
}
