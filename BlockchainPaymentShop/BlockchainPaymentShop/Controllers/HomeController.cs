using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlockChainPaymentShop.Models;
using Microsoft.AspNetCore.SignalR;
using BlockChainPaymentShop.Hubs;

namespace BlockChainPaymentShop.Controllers
{

   /**
    * Used to define main interactions with MVC application 
    * 
    * @author Davain Pablo Edwards
    * @license MIT 
    * @version 1.0
    */
    public class HomeController : Controller
    {

        /*
         * Constructor()
         */
        public HomeController(IHubContext<ChatHub> hubContext)
        {
            HubContext = hubContext;
        }

        /*
         * Initial hub context interface 
         * 
         */
        public IHubContext<ChatHub> HubContext
        {
            get;
            set;
        }

        /*
         * Index() action Method to show videos on 'index' view
         * 
         * @return View()
         */
        public IActionResult Index()
        {
            var lstVideo = ListVideo.Videoes();
            ViewBag.Videoes = lstVideo;
            return View();
        }

       /*
        * QrGenerate() action Method to show 'qrgenerate' view 
        * 
        * @return View()
        */
        public IActionResult QrGenerate()
        {
            return View();
        }

       /*
        * ApiCall() action Method to call API inter alia IP testing
        * 
        * @param ip
        * @param id
        * @return Content()
        */
        public async Task<IActionResult> ApiCall(string ip, int id)
        {

            await this.HubContext.Clients.All.SendAsync(ip, id, ListVideo.Videoes().First(x => x.Id == Convert.ToInt32(id)).URL);
            VideoOwned.AddUser(ip, id);
            return Content("successfull");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
