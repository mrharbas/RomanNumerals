using System.Collections.Generic;

namespace RomanNumeralsAPI.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public int? DecimalValue { get; set; }
        public string RomanNumeralValue { get; set; }
        public string Message { get; set; }

        public IList<RomanValue> ExplainedValue { get; set; }
    }
}
