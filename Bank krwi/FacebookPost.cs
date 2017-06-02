using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank_krwi
{
   public class FacebookPost
    {
        public string created_time { get; set; }
        public string message { get; set; }
        public string id { get; set; }

        public FacebookPost(string created_time, string message, string id)
        {
            this.created_time = created_time;
            this.message = message;
            this.id = id;
        }
    }


}
