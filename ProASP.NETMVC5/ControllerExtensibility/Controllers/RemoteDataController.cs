using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers
{
    public class RemoteDataController : Controller
    {
        
        public async Task<ActionResult> Data()
        {
            String data = await Task<String>.Factory.StartNew(() => {
                RemoteService service = new RemoteService();
                return service.GetRemoteData();
            });

            return View((Object)data);
        }

        // Here the browser will still lock up for two seconds, but the server will not!
        public async Task<ActionResult> ConsumeAsyncMethod()
        {
            RemoteService service = new RemoteService();
            String data = await service.GetRemoteDataAsync();

            return View("Data", (Object)data);
        }
    }
}