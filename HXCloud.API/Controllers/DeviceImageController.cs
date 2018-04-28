using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HXCloud.ModelView;
using HXCloud.Service;
using System.IO;
using System.Web.Hosting;
using System.Threading.Tasks;
using System.Web;
using HXCloud.ModelView.BaseData;

namespace HXCloud.API.Controllers
{
    /// <summary>
    /// 设备图片信息
    /// </summary>
    public class DeviceImageController : ApiController
    {
        private DeviceImageService _dis;
        /// <summary>
        /// 
        /// </summary>
        public DeviceImageController()
        {
            _dis = new DeviceImageService();
        }

        ///// <summary>
        ///// 添加设备图片数据
        ///// </summary>
        ///// <param name="dvm"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public DeviceImageViewModel DeviceImageAdd(DeviceImageViewModel dvm)
        //{
        //    return _dis.DeviceImageAdd(dvm);
        //}

        /// <summary>
        /// 上传设备图片(参数为用户名，组织编号，设备编号,图片所属面板编号，图片名称)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<DeviceImageViewModel> DeviceImageUpload()
        {
            DeviceImageViewModel divm = new DeviceImageViewModel();
            string account = HttpContext.Current.Request.Form["account"].ToString();
            string token = HttpContext.Current.Request.Form["token"].ToString();
            string deviceSn = HttpContext.Current.Request.Form["deviceSn"].ToString();
            string imageName = HttpContext.Current.Request.Form["imageName"].ToString();
            int panelId = Convert.ToInt32(HttpContext.Current.Request.Form["panelId"]);
            //验证用户是否有权限添加设备图片
            DeviceViewModel dvm = new DeviceService().FindDevice(account, token, deviceSn);
            if (dvm.Success == false)
            {
                divm.Success = false;
                divm.Message = "不存在该设备";
                return divm;
            }
            int projectId = dvm.ProjectId.Value;
            bool bRet = new UserService().IsAuthProject(account, token, projectId,2);
            if (!bRet)
            {
                divm.Success = false;
                divm.Message = "该用户没有添加图片的权限";
                return divm;
            }
            //保存设备图片至系统指定的目录
            string guid = Guid.NewGuid().ToString("N");
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            //每一个组织一个目录
            string uploadFolderPath = HostingEnvironment.MapPath("~/Images/Devices/" + token);

            //如果路径不存在，创建路径
            if (!Directory.Exists(uploadFolderPath))
                Directory.CreateDirectory(uploadFolderPath);

            List<string> files = new List<string>();
            var provider = new WithExtensionMultipartFormDataStreamProvider(uploadFolderPath, guid);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                //string token = provider.FormData["account"].ToString();
                //string account = provider.FormData["token"].ToString();
                // This illustrates how to get the file names.

                foreach (var file in provider.FileData)
                {//接收文件
                    files.Add(Path.GetFileName(file.LocalFileName));
                }
                //保存数据
                string url = "/Images/Devices/" + token + "/" + files[0];
                divm = _dis.AddDeviceImage(deviceSn, panelId, imageName, url);
            }
            catch (Exception ex)
            {
                divm.Success = false;
                divm.Message = "添加图片失败" + ex.Message;
                //string m = ex.Message;
                //files.Add(m);
            }
            return divm;
        }
        /// <summary>
        /// 更新设备图片名称
        /// </summary>
        /// <param name="divm"></param>
        /// <returns>返回更新设备图片名称是否成功</returns>
        [HttpPut]
        public ResponseData UpdateDeviceImage(DeviceImageViewModel divm)
        {
            return _dis.UpdateDeviceImage(divm);
        }



        /// <summary>
        /// 获取设备图片信息
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <param name="deviceSn"></param>
        /// <returns></returns>
        [HttpGet]
        public DeviceImageListViewModel GetDeviceImage(string account, string token, string deviceSn)
        {
            return _dis.GetDeviceImages(account, token, deviceSn);
        }
    }

    public class WithExtensionMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public string guid { get; set; }

        public WithExtensionMultipartFormDataStreamProvider(string rootPath, string guidStr)
            : base(rootPath)
        {
            guid = guidStr;
        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            string extension = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? Path.GetExtension(GetValidFileName(headers.ContentDisposition.FileName)) : "";
            return guid + extension;
        }

        private string GetValidFileName(string filePath)
        {
            char[] invalids = System.IO.Path.GetInvalidFileNameChars();
            return String.Join("_", filePath.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
        }
    }
}
