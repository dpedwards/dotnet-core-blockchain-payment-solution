using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentShop.Models
{

   /**
    * Used to define user 
    * 
    * @author Davain Pablo Edwards
    * @license MIT
    * @version 1.0
    */
    public class User
    {

        public string Ip { get; set; }
        public int Id { get; set; }
        public virtual List<Video> Videos { get; set; }

    }

    public static class VideoOwned
    {
        public static List<User> users = new List<User>();

        /*
         * AddUser() static Method to return user list by ip and id
         * @param ip
         * @param id
         * @return users
         */ 
        public static List<User> AddUser(string ip, int id)
        {
            if (users.FirstOrDefault(x => x.Ip == ip && x.Id == id) == null)
            {
                var user = new User { Ip = ip, Id = id };
                users.Add(user);
            }

            return users;
        }
    }
}
