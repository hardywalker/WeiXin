using System;

namespace WX_Tools
{
    /// <summary>
    /// 生成时间戳
    /// </summary>
   public class GetCreateTime
    {

     

        /// <summary>
        /// 取得时间戳  格林威治时间  1970,1,1,00:00开始到当前时间的秒数
        /// 中国是  1790,1,1,08:00
        /// </summary>
        /// <returns></returns>
        public int CreateTime()
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 8, 0, 0);
            return (int)(DateTime.Now - dateTime).TotalSeconds;

        }
    }
}
