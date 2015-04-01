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
       /// <summary>
       /// appid
       /// </summary>
       public  string Appid { get; set; }

       /// <summary>
       /// secret
       /// </summary>
       public  string Secret { get; set; }


       /// <summary>
       /// Token
       /// </summary>
        public string Token { get; set; }
    }
}
