using DotNetTrainingBatch4.RestApiWithNLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace YLADotNetCore.RestApiWithNLayer.Features.LatHtaukBayDin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatHtaukBayDinController : ControllerBase
    {
        private async Task<LatHtaukBayDinModel> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<LatHtaukBayDinModel>(jsonStr);
            return model;
        }
        //api/LatHtaukBayDin/questions
        [HttpGet("Questions")]
        public async Task<IActionResult> Questions()
        {
            var model = await GetDataAsync();
            return Ok(model.questions);
        }

        [HttpGet]
        public async Task<IActionResult> NumberList()
        {
            var model = await GetDataAsync();
            return Ok(model.numberList);
        }

        [HttpGet("{questionNo}/{no}")]
        public async Task<IActionResult> NumberList(int questionNo, int no)
        {
            var model = await GetDataAsync();
            return Ok(model.answers.FirstOrDefault(x => x.questionNo == questionNo && x.answerNo == no));
        }

        //static int ToNumber(string num)
        //{
        //    num = num.Replace("၁", "1");
        //    num = num.Replace("၂", "2");
        //    num = num.Replace("၃", "3");
        //    num = num.Replace("၄", "4");
        //    num = num.Replace("၅", "5");
        //    num = num.Replace("၆", "6");
        //    num = num.Replace("၇", "7");
        //    num = num.Replace("၈", "8");
        //    num = num.Replace("၉", "9");
        //    num = num.Replace("၀", "0");
        //    return Convert.ToInt32(num);
        //}
    }
}
