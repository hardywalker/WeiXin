using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_Tools.Entites
{
    /// <summary>
    /// 错误日志实体类
    /// </summary>
public  class Log
    {

        private string logTxtPhyPath;

        /// <summary>
        /// 需要保存的物理路径 格式 /***/
        /// </summary>
        public string LogTxtPhyPath
        {
            get { return logTxtPhyPath; }
            set { logTxtPhyPath = value; }

        }


    }
}
