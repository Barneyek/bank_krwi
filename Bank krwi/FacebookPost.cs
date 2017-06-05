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

        public FacebookPost(string CreatedTime, string Message, string Id)
        {
            this.created_time = CreatedTime;
            this.message = Message;
            this.id = Id;
        }
    }


}
