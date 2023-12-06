using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RicisVueDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportMetaDataController : ControllerBase
    {
        [HttpGet(Name = "GetImportMetaData")]
        public IEnumerable<ImportMetaData> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new ImportMetaData
            {
                Betrachtungstag = DateTime.Now.AddDays(index),
                FileName = "ImportFile" + index,
                UseCase = "PricesEuro"
            });
            //.ToArray();
        }
    }
}
