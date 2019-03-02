using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlockChainClient.Models;

namespace BlockChainClient.Controllers
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
        public IActionResult Index()
        {
            return View();
        }

        /*
         * MakeTransactions() action Method to show 'make action' view 
         * 
         * @return View()
         */
        public IActionResult MakeTransaction()
        {
            return View();
        }

        /*
         * ViewTransaction() action Method to show 'transaction' view
         * 
         * @return View()
         */ 
        public IActionResult ViewTransaction()
        {
            return View();
        }

        /*
         * ViewTransaction() http web action method to post transactions on blockchain
         * 
         * @param nodeUrl
         * @return View()
         */ 
        [HttpPost]
        public IActionResult ViewTransaction(string nodeUrl)
        {
            var url = new Uri(nodeUrl + "/chain");
            ViewBag.Blocks = GetChain(url);
            return View();
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
