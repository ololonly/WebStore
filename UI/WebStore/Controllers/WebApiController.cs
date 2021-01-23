using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Clients.TestApi;

namespace WebStore.Controllers
{
    public class WebApiController : Controller
    {
        private readonly IValuesService _valuesService;

        public WebApiController(IValuesService valuesService)
        {
            _valuesService = valuesService;
        }
        public IActionResult Index()
        {
            var values = _valuesService.Get();

            return View(values);
        }
    }
}
