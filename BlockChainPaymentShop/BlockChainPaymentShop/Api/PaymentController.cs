using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using BlockChainPaymentShop.Hubs;
using BlockChainPaymentShop.Models;

namespace BlockChainPaymentShop.Api
{

    /**
    * Used to define payment on blockchain
    * 
    * @author Davain Pablo Edwards
    * @license MIT 
    * @version 1.0
    */
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api")]
    public class PaymentController : Controller
    {

        /*
        * Constructor()
        */
        public PaymentController(IHubContext<ChatHub> hubContext)
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
         * GetFullChain() http web action method to get full chain
         * 
         * @return data
         */
        [HttpGet("chain")]
        public async Task<IActionResult> FullChain()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var url = new Uri("http://localhost:63385" + "/chain");
                var response = await client.GetAsync(url);

                var content = await response.Content.ReadAsStringAsync();
                var model = new
                {
                    chain = new List<Block>(),
                    length = 0
                };
                var data = JsonConvert.DeserializeAnonymousType(content, model);

                return Ok(data);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /*
         * MakePayment() http web action method to post on blockchain 
         * 
         * @param transaction
         * @param ip
         * @param pid
         * @return data
         */
        [HttpPost("pay")]
        public async Task<IActionResult> MakePayment([FromBody]Transaction transaction, string ip, int pid)
        {
            var json = JsonConvert.SerializeObject(transaction);

            var uri = "http://localhost:63385/transactions/new";
            var stringContent = new StringContent(json, System.Text.UnicodeEncoding.UTF8, "application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync(uri, stringContent);
            var content = await response.Content.ReadAsStringAsync();
            var rsp = new { message = "" };
            var data = JsonConvert.DeserializeAnonymousType(content, rsp);

            if (data.message.Contains("Transaction will be added to Block") && ip != null)
            {
                //successfull and unlock the video
                await this.HubContext.Clients.All.SendAsync(ip, pid, ListVideo.Videoes().First(x => x.Id == pid).URL);
                VideoOwned.AddUser(ip, pid);
            }

            return Ok(data);
        }

    }
}