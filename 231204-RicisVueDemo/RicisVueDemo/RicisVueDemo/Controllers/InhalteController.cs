using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RicisVueDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InhalteController : ControllerBase
    {
        // GET: api/<InhalteController>?useCase=ReferenceRates&ricisInstance=Euro&betrachtungstag=41785
        [HttpGet]
        public IEnumerable<Inhalt> Get([FromQuery] string useCase, [FromQuery] string ricisInstance, [FromQuery] DateTime betrachtungstag)
        {
            Console.WriteLine( useCase + " " + ricisInstance + " " + betrachtungstag);
            return new Inhalt[] { new Inhalt { ReferenceRate = "EURAB", Date = betrachtungstag, Value = 1.11m, Id = "123" }
                                ,  new Inhalt { ReferenceRate = "EURAC", Date = betrachtungstag, Value = 2.11m, Id = "234" }
                                ,  new Inhalt { ReferenceRate = "EURAD", Date = betrachtungstag, Value = 3.11m, Id = "456" }
                                ,  new Inhalt { ReferenceRate = "EURAE", Date = betrachtungstag, Value = 4.11m, Id = "789" }};
        }

        //// GET api/<InhalteController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<InhalteController>
        [HttpPost]
        public void Post([FromBody] Inhalt[] inhalte)
        {
            Console.WriteLine($"{inhalte.Length} Inhalte erhalten." );
        }

        //// PUT api/<InhalteController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<InhalteController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
