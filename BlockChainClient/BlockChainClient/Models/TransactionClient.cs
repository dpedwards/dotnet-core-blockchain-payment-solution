using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainClient.Models
{

    /**
    * Used to define the blockchain client transactions.
    * 
    * @author Davain Pablo Edwards
    * @license MIT 
    * @version 1.0
    */
    public class TransactionClient
    {

        public decimal Amount { get; set; }
        public string RecipientAddress { get; set; }
        public string SenderAddress { get; set; }
        public string SenderPrivateKey { get; set; }
        public decimal Fees { get; set; }

       /**
        * Overrides and returns the amount string with recipient address and sender address string.
        * 
        * @return amount + recipient address + sender address
        */
        public override string ToString()
        {
            return Amount.ToString("0.00000000") + RecipientAddress + SenderAddress;
        }
    }
}
