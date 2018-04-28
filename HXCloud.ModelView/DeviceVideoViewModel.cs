using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DeviceVideoViewModel : ResponseBase
    {
        public int Id { get; set; }
        public string VideoName { get; set; }//摄像头名称
        public string Url { get; set; }
        public string VideoSn { get; set; }//视频设备的序列号
        public int Channel { get; set; } = 1;//设备的通道编号，IPC（摄像机）固定为1，NVR可能有多个通道
        public string SecurityCode { get; set; }
        public string DeviceSn { get; set; }

        public int PanelId { get; set; }
        public string Token { get; set; }
    }
}
