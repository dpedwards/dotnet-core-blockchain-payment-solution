
namespace XamarinWallet.Models
{

   /**
    * Used to define transaction model
    * 
    * @author Davain Pablo Edwards
    * @license MIT 
    * @version 1.0
    */
    public class Transaction
    {

        public decimal Amount { get; set; }
        public string Recipient { get; set; }
        public string Sender { get; set; } // public key 
        public string Signature { get; set; }
        public decimal Fees { get; set; }
        public string PrivateKey { get; set; }

        /*
         * Overrides and returns the amount string 
         * 
         * @return amount
         */
        public override string ToString()
        {
             return Amount.ToString("0.00000000") + Recipient + Sender;
        }


    }
}
