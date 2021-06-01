using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomanNumerals;
using RomanNumeralsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumeralsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RomanNumeralsController : ControllerBase
    {
        /// <summary>
        /// Converts from or to Roman Numerals
        /// </summary>
        /// <returns>Returns the value converted</returns>
        /// <response code="200">Returns the result parsed</response>
        /// <response code="400">If conversion is impossible</response>
        [HttpGet("[action]/{value}")]
        public IActionResult Parse(string value)
        {
            Result result = new(value);

            try
            {
                bool isNumber = int.TryParse(value, out int number);

                result.ValueResult = isNumber ? RomanNumerals.RomanNumerals.Converts(number) : RomanNumerals.RomanNumerals.Converts(value);
                result.Success = true;
                result.Message = "Success.";

                return Ok(result);
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;

                return BadRequest(result);
            }
        }
    }
}
