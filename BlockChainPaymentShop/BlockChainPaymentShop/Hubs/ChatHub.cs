using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentShop.Hubs
{

   /**
    * Used to define chat hub
    * 
    * @author Davain Pablo Edwards
    * @license MIT
    * @version 1.0
    */
    public class ChatHub : Hub
    {

        /*
         * SendMessage() Method to send user message
         * 
         * @param user
         * @param message
         * 
         */
         public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


    }
}
