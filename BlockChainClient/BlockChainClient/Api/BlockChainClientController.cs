using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockChainClient.Models;
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

        /*
         * NewTransaction() action Method to send any value (coin) over the blockchain
         * 
         * @return response
         */
        [HttpPost("generate/transaction")]
        public IActionResult NewTransaction(TransactionClient transaction)
        {
            var sign = RSA.RSA.Sign(transaction.SenderPrivateKey, transaction.ToString());
            var response = new { transaction = transaction, signature = sign };
            return Ok(response);
        }

    }
}