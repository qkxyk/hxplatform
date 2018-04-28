using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    public class DeviceVideoModel : IAggregateRoot
    {
        public int Id { get; set; }
        public string VideoName { get; set; }//摄像头名称
        public string Url { get; set; }//web视频播放地址
        public string VideoSn { get; set; }//视频设备的序列号
        public int Channel { get; set; } = 1;//设备的通道编号，IPC（摄像机）固定为1，NVR可能有多个通道
        public string SecurityCode { get; set; }//视频加密密码，即设备标签上的6位字母验证码，支持明文/密文两种格式,注意只有开启视频加密的时候需要填入


        public string DeviceSn { get; set; }//设备序列号
        public virtual DeviceModel Device { get; set; }

        public int PanelId { get; set; }
        public virtual DevicePanelModel DevicePanel { get; set; }
    }
}
