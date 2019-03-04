using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainClient.Models
{
    public class TransactionClient
    {
        public decimal amount { get; set; }
        public string recipient_address { get; set; }
        public string sender_address { get; set; }
        public string sender_private_key { get; set; }
        public decimal fees { get; set; }

        public override string ToString()
        {
            return amount.ToString("0.00000000") + recipient_address + sender_address;
        }
    }
}
