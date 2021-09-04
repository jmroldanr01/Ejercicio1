using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class GPSController : ApiController
    {
        // GET api/gps
        [HttpGet]
        [Route("api/gps")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.GPS_DATA.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // GET api/gps/5
        [HttpPost]
        [Route("api/gps")]
        public IHttpActionResult Add([FromBody]ML.GPS_DATA gps)
        {
            ML.Result result = BL.GPS_DATA.Add(gps);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [HttpPut]
        [Route("api/gps")]
        public IHttpActionResult Update(int Id,[FromBody]ML.GPS_DATA gps)
        {
            gps.Id = Id;
            ML.Result result = BL.GPS_DATA.Update(gps);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [HttpDelete]
        [Route("api/gps")]
        public IHttpActionResult Delete(int Id)
        {
            ML.GPS_DATA gps = new ML.GPS_DATA();
            gps.Id = Id;
            ML.Result result = BL.GPS_DATA.Delete(gps);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }


    }
}
