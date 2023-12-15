using Microsoft.AspNetCore.Mvc;
using _3_Semester_Class_Library;

namespace _3_Semester_Projekt_API.Controllers
{
    //Bjørn + Magnus

    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : Controller
    {
        private SMSLogRepositoryDB _data;
        public SMSController(SMSLogRepositoryDB data)
        {
            _data = data;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            IEnumerable<SMSLog> sms = _data.Get();

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
                SMSLog sms = _data.Delete(id);
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
