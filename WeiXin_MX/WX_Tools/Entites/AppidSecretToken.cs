using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_Tools.Entites
{
    /// <summary>
    /// appid以及secret实体类
    /// </summary>
   public  class AppidSecretToken
    {


        private string appid;

       /// <summary>
       /// appid
       /// </summary>
       public  string Appid {
           get { return appid; }
           set { appid = value; }
       }



        private string secret;
       /// <summary>
       /// secret
       /// </summary>
       public  string Secret {
           get { return secret; }
           set { secret = value; }
       }



        private string token;
       /// <summary>
       /// Token
       /// </summary>
        public string Token {
           get { return token; }
           set { token = value; }
        }
    }
}
