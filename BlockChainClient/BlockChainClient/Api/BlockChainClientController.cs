using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockChainClient.Api
{

   /**
    * Used to define blockchain client interactions
    * 
    * @author Davain Pablo Edwards
    * @license MIT 
    * @version 1.0
    */
    [Produces("application/json")]
    [Route("api/BlockChainClient")]
    [ApiController]
    public class BlockChainClientController : ControllerBase
    {

        /*
         * NewWallet() action Method to generate private and public key for wallet 
         * 
         * @return response
         */ 
        [HttpGet("wallet/new")]
        public IActionResult NewWallet()
        {
            var wallet = RSA.RSA.KeyGenerate();
            var response = new
            {
                privateKey = wallet.PrivateKey,
                publicKey = wallet.PublicKey
            };
            return Ok(response);
        }

    }
}