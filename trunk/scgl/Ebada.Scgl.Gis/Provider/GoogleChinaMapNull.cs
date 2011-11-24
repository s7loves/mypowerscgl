/**********************************************
系统:企业ERP
模块:城市地图
作者:Rabbit
创建时间:2011-9-6
最后一次修改:2011-6-3
***********************************************/
using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.MapProviders;
using GMap.NET;
using System.IO;

namespace Ebada.Scgl.Gis {
    public class GoogleChinaMapNull : GoogleChinaMapProvider {

        
        public new static readonly GoogleChinaMapNull Instance;
         GoogleChinaMapNull() {
            TryCorrectVersion = false;
         }
         static GoogleChinaMapNull() {
             Instance = new GoogleChinaMapNull();

        }
        readonly Guid id = new Guid("1213F763-0000-4AB6-A14A-D84D6BCC3425");
        public override Guid Id {
            get {
                return id;
            }
        }
        public override GMap.NET.PureImage GetTileImage(GMap.NET.GPoint pos, int zoom) {
            return GetTileImageUsingHttp(pos, zoom);
        }
        public event TileImageEventHandler OnNeedTileImage;
        public  PureImage GetTileImageUsingHttp(GMap.NET.GPoint pos, int zoom) {
           
            PureImage image = null;
            
            return image;
        }
    }
}
