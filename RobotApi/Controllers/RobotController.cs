using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace RobotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotController : Controller
    {
        //private static string Command { get; set; }
        private static Dictionary<string, string> DataPackage = new Dictionary<string, string>() {{ "command", "stop"},{ "angle", "0" } };

        [HttpGet("getcommands")]
        public string GetData()
        {
            System.Diagnostics.Debug.WriteLine("Get Time:" + DateTime.Now);
            var package = JsonSerializer.Serialize(DataPackage).ToString();
            DataPackage["command"] = "stop";
            return package;
        }
        [HttpPut("SetTurn")]
        public void SetTurn(string direction,int angle) 
        {
            System.Diagnostics.Debug.WriteLine("Put Time:"+DateTime.Now);
            DataPackage["command"] = direction;
            DataPackage["angle"] = angle.ToString();
            Console.WriteLine("api command: "+ DataPackage["command"] + DataPackage["angle"]);
        }
        [HttpPut("SetDirection")]
        public void SetDirection(string command)
        {
            System.Diagnostics.Debug.WriteLine("Put Time:" + DateTime.Now);
            DataPackage["command"] = command;
            Console.WriteLine("api command: " + DataPackage["command"]);
        }

    }
}
