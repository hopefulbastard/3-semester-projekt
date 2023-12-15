﻿using Microsoft.AspNetCore.Mvc;
using _3_Semester_Class_Library;

namespace _3_Semester_Projekt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : Controller
    {
        private SikkerhedsLogRepositoryDB _data;
        public SMSController(SMSRepositoryDB data)
        {
            _data = data;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            IEnumerable<SMSListe> sms = _data.Get();

            if (sms.ToList().Count == 0)
            {
                return NoContent();
            }
            return Ok(sms);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            try
            {
                SMSListe sms = _data.Delete(id);
                return Ok(sms);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe);
            }
            {

            }
        }
    }
}