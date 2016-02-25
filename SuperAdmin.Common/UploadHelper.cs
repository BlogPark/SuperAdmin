using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
        /// 本地上传文件 保存为jpg格式
        /// </summary>
        /// <param name="uploadFile">HttpPostedFileBase对象</param>
        /// <param name="filepath">文件保存路径</param>
        /// <param name="filetype">扩展名string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };</param>
        /// <param name="articlePicStr">资讯套图生成JsonStr，默认为空，isCreateArtclePic为true时有值</param>
        /// <param name="maxSize">最大多少kb(默认300kb)</param>
        /// <param name="rename">是否重命名</param>
        /// <param name="isCreateArtclePic">是否生成资讯套图（可选 默认 fasle）</param>
        /// <returns></returns>
        public static UploadFileModel UpLoadForSaveSuitjpg(System.Web.HttpPostedFileBase uploadFile, string filepath, string[] filetype, out string picjson, int maxSize = 300, bool isCreateArtclePic = false)
        {
            picjson = "";
            //判断保持路径和上传文件对象是否存在
            if (uploadFile == null)
                return new UploadFileModel() { status = "fail", message = "请选择上传图片" };
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

            string filename = CreateImageFileName() + currentType;
            string path = savePath + filename;
            uploadFile.SaveAs(path);
            path = path.Replace(filepath.TrimEnd('/').TrimEnd('\\'), "");
            System.Drawing.Image img = System.Drawing.Image.FromStream(uploadFile.InputStream);
            if (isCreateArtclePic)//如果需要生成套图
            {
                picjson = CreateArticlePic(img, savePath, filename, filepath);
            }
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
        /// 生成资讯套图专用方法
        /// </summary>
        /// <param name="image">Image对象</param>
        /// <param name="fileDir">图片保存配置的物理根目录</param>
        /// <param name="fileName">图片根站点路径</param>
        /// <returns></returns>
        private static string CreateArticlePic(System.Drawing.Image image, string fileDir, string fileName,string sysfilepath)
        {
            if (image == null)
                return string.Empty;

            //生成160*160的Icon图片(用于移动版)
            string fullPath = string.Format("{0}/{1}", fileDir.TrimEnd('/').TrimEnd('\\'), fileName);
            CutImg(image, fullPath, 160, 160);//生成160*160

            //九张图
            int[] size = new int[] { 240, 320, 400, 480, 560, 640, 720, 800 };
            StringBuilder sb = new StringBuilder("{\"Image\":[");
            string newFullFileName = "";
            int newH = 0;
            foreach (var newW in size)
            {
                newFullFileName = CutImgAuto(image, fullPath, newW, out newH);
                if (!string.IsNullOrEmpty(newFullFileName))
                {
                    newFullFileName = newFullFileName.Replace(sysfilepath.TrimEnd('\\'), "");
                    sb.Append("{\"w\":\"" + newW + "\",\"h\":\"" + newH + "\",\"path\":\"" + newFullFileName + "\"},");
                }
            }
            sb.Append("]}");
            return sb.ToString().Replace("},]}", "}]}");
        }
        /// <summary>
        /// 网页版等比缩放,以宽为准；
        /// 生成新图片的宽或者高大于原图片的宽或者高则不生成
        /// </summary>
        /// <param name="img">源图Image</param>
        /// <param name="path">源图地址</param>
        /// <param name="newW">新宽</param>
        /// <param name="newH">生成图片的高度</param>
        /// <param name="encoderVal">图片质量</param>
        /// <returns>新图片路径</returns>
        public static string CutImgAuto(System.Drawing.Image img, string path, int newW, out int newH, long encoderVal = 84L)
        {
            newH = 0;
            if (path == "") { return string.Empty; }

            string newName = string.Format("{0}{1}", newW, System.IO.Path.GetExtension(path).ToLower());
            path = string.Format("{0}.{1}", path.TrimEnd('/').TrimEnd('\\'), newName);
            int x = 0, originalW = img.Width, originalH = img.Height, height = 0;
            if (newW >= originalW)
            {
                x = (newW - originalW) / 2;
                height = originalH;
            }
            else if (newW < originalW)
            {
                originalH = originalH * newW / originalW; originalW = newW;
                height = originalH;
            }

            newH = height;
            //生成新图片的宽或者高大于原图片的宽或者高则不生成
            if (newH > img.Height || newW > img.Width)
                return string.Empty;

            try
            {
                System.Drawing.Image newImg = new Bitmap(newW, height);
                using (Graphics g = Graphics.FromImage(newImg))
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.Clear(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    g.DrawImage(img, new Rectangle(x, 0, originalW + 1, originalH + 1), new Rectangle(1, 1, img.Width, img.Height), GraphicsUnit.Pixel);
                    g.Dispose();
                }
                EncoderParameters myParas = new EncoderParameters();
                myParas.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, encoderVal);
                newImg.Save(path, ImageCodecInfo.GetImageEncoders()[1], myParas);
                myParas.Param[0].Dispose();
                myParas.Dispose();
                newImg.Dispose();
            }
            catch
            {
                return string.Empty;
            }

            return path;
        }
        /// <summary>移动版,图片裁剪,裁减为正方形</summary>
        /// <param name="img">源图Image</param>
        /// <param name="path">保存路径</param>
        /// <param name="newW">新宽</param>
        /// <param name="newH">新高</param>
        /// <returns>新图片路径</returns>
        public static string CutImg(System.Drawing.Image img, string path, int newW, int newH)
        {
            if (path == "") { return string.Empty; }

            string newName = string.Format("{0}_{1}{2}", newW, newH, System.IO.Path.GetExtension(path).ToLower());
            path = string.Format("{0}.{1}", path.TrimEnd('/').TrimEnd('\\'), newName);

            double imgScale = img.Width / (double)img.Height;
            int originalW = 0, originalH = 0;
            if (newW / (double)newH > imgScale)
            {
                originalW = newW > img.Width ? img.Width : newW; originalH = (int)(newW / imgScale);
                if (originalH > img.Height)
                {
                    originalH = img.Height;
                }
            }
            else
            {
                originalH = newH > img.Height ? img.Height : newH;
                originalW = (int)(originalH * imgScale);
                if (originalW > img.Width)
                {
                    originalW = img.Width;
                }
            }

            System.Drawing.Image newImg = new Bitmap(newW, newH);
            using (Graphics g = Graphics.FromImage(newImg))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.Clear(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                //g.DrawImage(img, new Rectangle((nw - vw) / 2, (nh - vh) / 2, vw, vh), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                g.DrawImage(img, new Rectangle((newW - originalW) / 2, newH < originalH ? ((newH - originalH) / 3) : 0, originalW + 1, originalH + 1), new Rectangle(1, 1, img.Width, img.Height), GraphicsUnit.Pixel);

                g.Dispose();
            }

            EncoderParameters myParas = new EncoderParameters();
            myParas.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 84L);
            newImg.Save(path, ImageCodecInfo.GetImageEncoders()[1], myParas);

            myParas.Param[0].Dispose();
            myParas.Dispose();
            newImg.Dispose();
            return path;
        }

        #region 生成路径节点信息
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
        #endregion
    }
}
