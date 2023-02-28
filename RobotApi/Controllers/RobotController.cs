using Microsoft.AspNetCore.Mvc;

namespace RobotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotController : Controller
    {
        private static string Command { get; set; }

        [HttpGet("info")]
        public string GetInfo()
        {
            var com = Command;
            Command = "stop";
            return com;
        }
        [HttpPut("SetCommand")]
        public void SetCommand(string command) 
        {
            
            Command = command;
            Console.WriteLine("api command: "+Command );
        }

    }
}
