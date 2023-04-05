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
        private static double[] RadarData=new double[20];

        [HttpGet("GetRadarData")]
        public string GetRadarData()
        {
            return JsonSerializer.Serialize(RadarData);
        } 
        [HttpGet("getcommands")]
        public string GetCommands()
        {
            System.Diagnostics.Debug.WriteLine("Get Time:" + DateTime.Now);
            var package = JsonSerializer.Serialize(DataPackage).ToString();
            DataPackage["command"] = "stop";
            return package;
        }
        [HttpPut("SetTurn")]
        public void SetTurn([FromBody]Dictionary<string,string> content) 
        {
            
            DataPackage["command"] = content["direction"];
            DataPackage["angle"] = content["angle"];

            Console.WriteLine("api command: "+ DataPackage["command"] + DataPackage["angle"]);
        }
        [HttpPut("SetDirection")]
        public void SetDirection([FromBody]string command)
        {
            Console.WriteLine(command);
            DataPackage["command"] = command;
            Console.WriteLine("api command: " + DataPackage["command"]);
        }
        [HttpPost("RadarData")]
        public void ReceiveRadar([FromBody]double[] data)
        {
            RadarData = data;
            Console.WriteLine(data);
        }

    }
}
