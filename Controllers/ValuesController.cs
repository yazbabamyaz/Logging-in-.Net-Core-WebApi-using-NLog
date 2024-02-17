using ExamGlobalApi.Exceptions;
using ExamGlobalApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamGlobalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //DI
        private readonly ILogerService _loger;
        public ValuesController(ILogerService loger)
        {
            _loger = loger;
        }        

        //api/Values/Save
        [HttpPost]
        [Route("Save")]
        public IActionResult Add()
        {           
            throw new NotFoundException("Dosya bulunamadı.");  
            return Ok();
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            _loger.LogInfo("Write your info message");
            //NLog.config'te minlevel=Info olduğu için Debug gözükmeyecek.
            _loger.LogDebug("Write your debug message");
            _loger.LogWarn("Write your warn message");
            _loger.LogError("Write your error message");
            return Ok();            
        }


    }
}
