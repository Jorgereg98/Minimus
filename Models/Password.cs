using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimus.Models
{
    public class Password
    {
        public string Code { get; set; }
        public DifficultyEnum Difficulty { get; set; }

        public Password()
        {

        }

        public Password(DifficultyEnum difficulty, string code)
        {
            Difficulty = difficulty;
            Code = code;
        }

        public override string ToString()
        {
            return $"Password {Code} / Difficulty: {Difficulty}";
        }
    }
}
