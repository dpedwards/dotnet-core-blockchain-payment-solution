
namespace XamarinWallet.Models
{

  /**
   * Used to define RSA model
   * 
   * @author Davain Pablo Edwards
   * @license MIT 
   * @version 1.0
   */
    public static class RSA
    {

        /*
         * Sign() Method to serve with private and public key over NBitcoin network 
         * 
         * @param privateKey
         * @param messageToSign
         * @return signature
         */
         public static string Sign(string privateKey, string messageToSign)
         {
            var secret = NBitcoin.Network.Main.CreateBitcoinSecret(privateKey);
            var signature = secret.PrivateKey.SignMessage(messageToSign);
            var v = secret.PubKey.VerifyMessage(messageToSign, signature);

            return signature;
         }
    }
}
