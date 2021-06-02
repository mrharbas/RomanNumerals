using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumeralsAPI.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public int? DecimalValue { get; set; }
        public string RomanNumeralValue { get; set; }
        public string Message { get; set; }
    }
}
