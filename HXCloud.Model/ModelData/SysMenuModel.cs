using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.Model
{
    public class SysMenuModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>    
        public string Id { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public string ParentId { get; set; }
        public virtual SysMenuModel Parent { get; set; }
        public virtual ICollection<SysMenuModel> Child { get; set; }

        public virtual ICollection<RoleSysMenuModel> RoleSysMenu { get; set; }
        public string Token { get; set; }
        public virtual GroupModel Group { get; set; }


        /// <summary>
        /// 菜单组内排序
        /// </summary>
       // public int IndexCode { get; set; }

        /// <summary>
        /// 菜单路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 类型：0导航菜单；1操作按钮。
        /// </summary>
        public MenuTypes? MenuType { get; set; }

        /// <summary>
        /// 菜单图标名称
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 菜单备注
        /// </summary>
        public string Remarks { get; set; }
    }

    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuTypes
    {
        /// <summary>
        /// 导航菜单
        /// </summary>
        导航菜单,
        /// <summary>
        /// 操作菜单
        /// </summary>
        操作菜单
    }
}
