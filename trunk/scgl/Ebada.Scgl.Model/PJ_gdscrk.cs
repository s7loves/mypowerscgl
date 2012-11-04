/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-3-1 21:52:29
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_clcrkd]业务实体类
    ///对应表名:PJ_clcrkd
    /// </summary>
    [Serializable]
    public class PJ_gdscrk
    {

        #region Private 成员
        private string _id = Newid();
        private string _num = String.Empty;
        private string _orgcode = String.Empty;
        private string _wpmc = String.Empty;
        private string _wpgg = String.Empty;
        private string _wpdw = String.Empty;
        private string _wpsl = String.Empty;
        private string _wpdj = String.Empty;
        private string _wpcj = String.Empty;
        private string _ly = String.Empty;
        private DateTime _indate = DateTime.Now;
        private DateTime _ckdate = DateTime.Now;
        private string _kcsl = String.Empty;
        private string _yt = String.Empty;
        private string _remark = String.Empty;
        private string _type = String.Empty;
        private DateTime _lasttime = DateTime.Now;
        private string _cksl = String.Empty;
        #endregion


        #region Public 成员

        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ID
        {
            get { return _id; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：num
        /// 属性描述：出入库单号
        /// 字段信息：[num],nvarchar
        /// </summary>
        [DisplayNameAttribute("出入库单号")]
        public string num
        {
            get { return _num; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[出入库单号]长度不能大于50!");
                if (_num as object == null || !_num.Equals(value))
                {
                    _num = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：供电所代码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所代码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[供电所代码]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：wpmc
        /// 属性描述：物品名称
        /// 字段信息：[wpmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("物品名称")]
        public string wpmc
        {
            get { return _wpmc; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[物品名称]长度不能大于50!");
                if (_wpmc as object == null || !_wpmc.Equals(value))
                {
                    _wpmc = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：wpgg
        /// 属性描述：物品规格
        /// 字段信息：[wpgg],nvarchar
        /// </summary>
        [DisplayNameAttribute("物品规格")]
        public string wpgg
        {
            get { return _wpgg; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[物品规格]长度不能大于50!");
                if (_wpgg as object == null || !_wpgg.Equals(value))
                {
                    _wpgg = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：wpdw
        /// 属性描述：物品单位
        /// 字段信息：[wpdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("物品单位")]
        public string wpdw
        {
            get { return _wpdw; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[物品单位]长度不能大于50!");
                if (_wpdw as object == null || !_wpdw.Equals(value))
                {
                    _wpdw = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：wpsl
        /// 属性描述：数量
        /// 字段信息：[wpsl],nvarchar
        /// </summary>
        [DisplayNameAttribute("数量")]
        public string wpsl
        {
            get { return _wpsl; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[数量]长度不能大于50!");
                if (_wpsl as object == null || !_wpsl.Equals(value))
                {
                    _wpsl = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：wpdj
        /// 属性描述：单价
        /// 字段信息：[wpdj],nvarchar
        /// </summary>
        [DisplayNameAttribute("单价(单位:元)")]
        public string wpdj
        {
            get { return _wpdj; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[单价]长度不能大于50!");
                if (_wpdj as object == null || !_wpdj.Equals(value))
                {
                    _wpdj = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：wpcj
        /// 属性描述：厂家
        /// 字段信息：[wpcj],nvarchar
        /// </summary>
        [DisplayNameAttribute("厂家")]
        public string wpcj
        {
            get { return _wpcj; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[厂家]长度不能大于50!");
                if (_wpcj as object == null || !_wpcj.Equals(value))
                {
                    _wpcj = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：ckdate
        /// 属性描述：出库时间
        /// 字段信息：[ckdate],datetime
        /// </summary>
        [DisplayNameAttribute("出库时间")]
        public DateTime ckdate
        {
            get { return _ckdate; }
            set
            {
                if (_ckdate as object == null || !_ckdate.Equals(value))
                {
                    _ckdate = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：yt
        /// 属性描述：用途
        /// 字段信息：[yt],nvarchar
        /// </summary>
        [DisplayNameAttribute("用途")]
        public string yt
        {
            get { return _yt; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[用途]长度不能大于50!");
                if (_yt as object == null || !_yt.Equals(value))
                {
                    _yt = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：cksl
        /// 属性描述：出库数量
        /// 字段信息：[cksl],nvarchar
        /// </summary>
        [DisplayNameAttribute("出库数量")]
        public string cksl
        {
            get { return _cksl; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[出库数量]长度不能大于50!");
                if (_cksl as object == null || !_cksl.Equals(value))
                {
                    _cksl = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：kcsl
        /// 属性描述：该物品库存数量
        /// 字段信息：[kcsl],nvarchar
        /// </summary>
        [DisplayNameAttribute("该物品库存数量")]
        public string kcsl
        {
            get { return _kcsl; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[该物品库存数量]长度不能大于50!");
                if (_kcsl as object == null || !_kcsl.Equals(value))
                {
                    _kcsl = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：ly
        /// 属性描述：来源
        /// 字段信息：[ghdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("来源")]
        public string ly
        {
            get { return _ly; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[来源]长度不能大于50!");
                if (_ly as object == null || !_ly.Equals(value))
                {
                    _ly = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：indate
        /// 属性描述：入库时间
        /// 字段信息：[indate],datetime
        /// </summary>
        [DisplayNameAttribute("入库时间")]
        public DateTime indate
        {
            get { return _indate; }
            set
            {
                if (_indate as object == null || !_indate.Equals(value))
                {
                    _indate = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：备注
        /// 字段信息：[Remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[备注]长度不能大于50!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：type
        /// 属性描述：类型
        /// 字段信息：[type],nvarchar
        /// </summary>
        [DisplayNameAttribute("类型")]
        public string type
        {
            get { return _type; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[类型]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：lasttime
        /// 属性描述：最后修改时间
        /// 字段信息：[lasttime],datetime
        /// </summary>
        [DisplayNameAttribute("最后修改时间")]
        public DateTime lasttime
        {
            get { return _lasttime; }
            set
            {
                if (_lasttime as object == null || !_lasttime.Equals(value))
                {
                    _lasttime = value;
                }
            }
        }

        [DisplayNameAttribute("总入库量")]
        public string rkslcount { get; set; }

        [DisplayNameAttribute("总出库量")]
        public string ckslcount { get; set; }

        [DisplayNameAttribute("剩余库存")]
        public string kcslcount { get; set; }

        #endregion

        #region 方法
        public static string Newid()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        }
        public string CreateID()
        {
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            return DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        }
        #endregion
    }
}
