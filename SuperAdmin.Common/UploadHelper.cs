using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.datamodel;

namespace SuperAdmin.Common
{
    /// <summary>
    /// 上传图片辅助类
    /// </summary>
    public class UploadHelper
    {
        public static UploadFileModel LocalUpLoadForSingle(System.Web.HttpPostedFileBase uploadFile, string filepath, string[] filetype, int maxSize = 300, string newfilename = "")
        {
            //判断保持路径和上传文件对象是否存在
            if (uploadFile == null)
                return new UploadFileModel() { status = "fail", message = "文件不存在" };

            if (string.IsNullOrEmpty(filepath))
                return new UploadFileModel() { status = "fail", message = "请配置图片保存路径" };

            float fileSize = uploadFile.ContentLength <= 0 ? 0 : uploadFile.ContentLength / 1024;

            //验证文件质量
            if (fileSize <= 1 || fileSize > maxSize)
                return new UploadFileModel() { status = "fail", message = "图片不能超过" + maxSize + "kb,且不能小于1kb" };

            //格式验证
            string currentType = Path.GetExtension(uploadFile.FileName);
            if (Array.IndexOf(filetype, currentType) == -1)
                return new UploadFileModel() { status = "fail", message = "图片格式错误" };

            string savePath = filepath.TrimEnd('/').TrimEnd('\\') + "/" + CreateFolder(DateTime.Now) + "/";
            //判断保持路径是否存在
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);
            else
            {
                string newSavePath = CreateChildDir(savePath);
                if (newSavePath != savePath)
                {
                    Directory.CreateDirectory(newSavePath);
                    savePath = newSavePath;
                }
            }

            string filename = "";

            if (string.IsNullOrWhiteSpace(newfilename))
                filename = CreateImageFileName() + currentType;
            else
                filename = newfilename + currentType;

            string path = savePath + filename;
            uploadFile.SaveAs(path);
            path = path.Replace(filepath.TrimEnd('/').TrimEnd('\\'), "");

            System.Drawing.Image img = System.Drawing.Image.FromStream(uploadFile.InputStream);
            UploadFileModel model = new UploadFileModel();
            model.status = "success";
            model.message = "上传成功";
            model.filename = filename;
            model.filepath = path;
            model.filesize = fileSize;
            model.width = img.Width;
            model.height = img.Height;
            img.Dispose();
            return model;
        }

        /// <summary>
        /// 生成文件夹
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string CreateFolder(DateTime dt)
        {
            string folder = dt.ToString("yyyyMMdd");
            Dictionary<string, string> numericDict = NumericDict();
            foreach (var kv in numericDict)
                folder = folder.Replace(kv.Key, kv.Value);
            return folder;
        }
        private static Dictionary<string, string> NumericDict()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("0", "X");
            dict.Add("1", "I");
            dict.Add("2", "II");
            dict.Add("3", "3");
            dict.Add("4", "IV");
            dict.Add("5", "V");
            dict.Add("6", "VI");
            dict.Add("7", "7");
            dict.Add("8", "H");
            dict.Add("9", "IX");
            return dict;
        }
        /// <summary>
        /// 生成二级文件夹名
        /// </summary>
        /// <param name="savePath"></param>
        /// <param name="maxFile"></param>
        /// <returns></returns>
        public static string CreateChildDir(string savePath, int maxFile = 1000)
        {
            //声明并初始化DirectoryInfo对象
            DirectoryInfo dirInfo = new DirectoryInfo(savePath);
            //获取文件夹下所有的文件
            FileInfo[] files = dirInfo.GetFiles();
            //判断文件数量是否达到maxFile的上限
            if (files.Count() > maxFile)
            {
                //读取子文件夹
                DirectoryInfo[] childDir = dirInfo.GetDirectories();
                Int32 childNo = 1;
                //判断子文件夹是否存在
                if (childDir != null && childDir.Any())
                {
                    //获取最后一个创建的子文件
                    var myChildDir = childDir.Where(m => System.Text.RegularExpressions.Regex.IsMatch(m.Name, @"\d+"));
                    if (myChildDir != null && myChildDir.Any())
                    {
                        DirectoryInfo lastDir = myChildDir.OrderBy(m => m.CreationTime).Last();
                        //判断子文件夹下的文件重量是否达到maxFile上限
                        if (lastDir.GetFiles() != null && lastDir.GetFiles().Any())
                        {
                            string childDirName = lastDir.Name;

                            if (lastDir.GetFiles().Count() > maxFile)
                            {
                                childNo = Convert.ToInt32(childDirName) + 1;
                                savePath = string.Format("{0}/{1}/", savePath.Trim('/'), childNo);
                            }
                            else
                            {
                                savePath = string.Format("{0}/{1}/", savePath.Trim('/'), childDirName);
                            }
                        }
                        else
                        {
                            savePath = string.Format("{0}/{1}/", savePath.Trim('/'), childNo);
                        }
                    }
                    else
                    {
                        savePath = string.Format("{0}/{1}/", savePath.Trim('/'), childNo);
                    }
                }
                else
                {
                    savePath = string.Format("{0}/{1}/", savePath.Trim('/'), childNo);
                }

            }


            return savePath;
        }
        /// <summary>
        /// 生成文件名称
        /// </summary>
        /// <returns></returns>
        public static string CreateImageFileName()
        {
            string treadName = System.Threading.Thread.CurrentThread.Name;
            string fix = "";
            if (!string.IsNullOrEmpty(treadName) && treadName.IndexOf("?") != -1)
            {
                fix = treadName.Split('?')[1];
            }
            string ticks = DateTime.Now.Ticks.ToString();
            Dictionary<string, string> numericDict = NumericDict();
            foreach (var kv in numericDict)
                ticks = ticks.Replace(kv.Key, kv.Value);
            return string.Format("{0}{1}", ticks, fix);
        }
    }
}
