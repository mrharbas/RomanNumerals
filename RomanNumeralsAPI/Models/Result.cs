using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumeralsAPI.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public object ValueToParse { get; set; }
        public object ValueResult { get; set; }
        public string Message { get; set; }

        public Result(object valueToParse)
        {
            ValueToParse = valueToParse;
        }
    }
}
