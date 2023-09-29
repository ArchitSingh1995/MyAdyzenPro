using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class JoinTableController : Controller
    {
        // GET: JoinTable
        public ActionResult Index()
        {
            IEnumerable<JoinTableClass> sm = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44300/api/JoinApi");
            var consumeapi = hc.GetAsync("JoinApi");
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<JoinTableClass>>();
                displaydata.Wait();
                sm = displaydata.Result;
            }
            return View(sm);
        }
    }
}