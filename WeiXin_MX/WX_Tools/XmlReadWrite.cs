using System;
using System.IO;
using System.Web;
using System.Xml.Serialization;
using WX_Tools.Entites;

namespace WX_Tools
{
    /// <summary>
    /// Xml文件读写类
    /// </summary>
    public static class XmlReadWrite
    {



        /// <summary>
        /// 根据相对路径以及文件全名读取xml文件，需要传入实体对象类型   反序列化方式
        /// </summary>
        /// <param name="filePath">相对路径(/aa/aa/)</param>
        /// <param name="obj">实体对象类型</param>
        /// <param name="fileName">文件名（a.txt）</param>
        /// <returns>返回对象</returns>
        public static Object Read(string filePath, object obj, string fileName)
        {
            //获取物理路径 
            filePath = HttpContext.Current.Server.MapPath(filePath);
            //判断路径是否存在，不存在创建路径 
            if (Directory.Exists(filePath))
            {
                filePath = Path.Combine(filePath, fileName);
                //根据路径 ，把文件放入文件流
                FileStream fileStream=null;
                try
                {
                    fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                    return xmlSerializer.Deserialize(fileStream);
                }
                catch (Exception ex)
                {
                    new DebugLog().BugWriteTxt(new Log().LogTxtPhyPath, ex.ToString());
                }
                finally
                {
                    if (fileStream != null)
                    {
                        fileStream.Close();
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// 根据相对路径来生成xml文件，需要传入实体对象  序列化方式
        /// </summary>
        /// <param name="filePath">相对路径(/aa/aaa/)</param>
        /// <param name="obj">实体对象</param>
        /// <param name="fileName">文件全名(a.config)</param>
        public static void Write(string filePath, object obj, string fileName)
        {
            //获取物理路径 
            filePath = HttpContext.Current.Server.MapPath(filePath);
            //判断路径是否存在，不存在创建路径 
            DirectoryIsExists(filePath);
            filePath = Path.Combine(filePath, fileName);
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                xmlSerializer.Serialize(fileStream, obj);
            }
            catch (Exception ex)
            {
                new DebugLog().BugWriteTxt(new Log().LogTxtPhyPath, ex.ToString());
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

        }


        /// <summary>
        /// 判断xml所在文件夹是否存在，不存在的话，就创建此路径，注意传入的路径是物理路径
        /// </summary>
        /// <param name="filePath">物理路径</param>
        private static void DirectoryIsExists(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

        }


    }
}
