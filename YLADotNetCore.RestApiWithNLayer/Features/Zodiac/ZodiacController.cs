using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static YLADotNetCore.RestApiWithNLayer.Features.LatHtaukBayDin.LatHtaukBayDinController;

namespace YLADotNetCore.RestApiWithNLayer.Features.Zodiac
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ZodiacController : ControllerBase
    {
        private async Task<ZodiacModel> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("data2.json");
            var model = JsonConvert.DeserializeObject<ZodiacModel>(jsonStr);
            return model;
        }

        [HttpGet]
        public async Task<IActionResult> ZodiacSignsDetail()
        {
            var model = await GetDataAsync();
            return Ok(model.ZodiacSignsDetail);
        }

        //[HttpGet("{name}")]
        //public async Task<IActionResult> ZodiacSignsDetails(string name)
        //{
        //    var model = await GetDataAsync();
        //    return Ok(model.ZodiacSignsDetail.FirstOrDefault(x => x.Name == name));
        //}

        [HttpGet("{date}")]
        public async Task<IActionResult> ZodiacSignsDetails(string date)
        {
            var model = await GetDataAsync();
            return Ok(model.ZodiacSignsDetail.FirstOrDefault(x => x.Dates == date));
        }
    }
}
