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
    public class GoogleChinaMap : GoogleChinaMapProvider {

        public TONLI.MapCore.IMapServer Mapserver {
            get { return Client.ClientServer.PlatformServer.GetService<TONLI.MapCore.IMapServer>(); }
        }
        string type = "m1_";
        public new static readonly GoogleChinaMap Instance;
         GoogleChinaMap() {
            TryCorrectVersion = false;
         }
        static GoogleChinaMap() {
            Instance = new GoogleChinaMap();

        }
        readonly Guid id = new Guid("1213F763-0001-4AB6-A14A-D84D6BCC3425");
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
            TileImageEventArgs args = new TileImageEventArgs(pos, zoom);
            args.Image = MapHelper.GetImage(type, args.Url);
            if (args.Image == null) {
                if (OnNeedTileImage != null) {
                    OnNeedTileImage(image, args);

                } else {
                    args.Image = Mapserver.GetImage(type, args.Url);
                    if (args.Image != null) {
                        MapHelper.SetImage(type, args.Url, args.Image);
                    }
                }
            }
            if (args.Image != null) {
                MemoryStream stream = new MemoryStream(args.Image);
                image = TileImageProxy.FromStream(stream);
                if (image != null)
                    image.Data = stream;
                args.Image = null;
            }

            return image;
        }
    }
}
