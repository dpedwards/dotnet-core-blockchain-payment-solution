using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentShop.Models
{

   /**
    * Used to define video
    * 
    * @author Davain Pablo Edwards
    * @license MIT
    * @version 1.0
    */
    public class Video
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public virtual List<User> Users { get; set; }

    }

    public static class ListVideo
    {
        public static List<Video> Videoes()
        {
            var lstVideo = new List<Video> {
                new Video { Id = 1, Title = "Marvel Studios' Avengers Endgame", URL = "hVSpac8wx3I",Image="",Price=3},
                new Video { Id = 2, Title = "John Wick: Chapter 3 - Parabellum", URL = "-7p2uC7E5Rs",Image="",Price=2},
                new Video { Id = 3, Title = "Game of Thrones Season 8", URL = "wA38GCX4Tb0",Image="",Price=5},
                new Video { Id = 4, Title = "Godzilla: King of the Monsters", URL = "5kUyJzdiwFQ",Image="",Price=1},
                new Video { Id = 5, Title = "X-Men Dark Phoenix", URL = "q5v7Ch4bxzc",Image="",Price=6},
                new Video { Id = 6, Title = "Alita Battle Angel", URL = "w7pYhpJaJW8",Image="",Price=6}
            };

            return lstVideo;
        }
    }
}
