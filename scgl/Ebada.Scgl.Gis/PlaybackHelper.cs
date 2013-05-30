using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using System.ComponentModel;
using GMap.NET.WindowsForms;
using Ebada.Scgl.Gis.Markers;
using System.Drawing;
using System.Collections;
using GMap.NET.WindowsForms.Markers;

namespace Ebada.Scgl.Gis {
    public class PlaybackHelper {
        private RMap _map;
        private int deviceid;
        private PlayBackType playstate= PlayBackType.None;
        Queue<gps_position> queue_pos;
        private int speed = 1;
        private DateTime startTime;
        Timer dataTimer;
        Timer playTimer;
        GMapOverlay playOverlay;
        GMapMarker car;
        GMapRoute playRoute;
        int nStart=0,
            nLimit=50, 
            nTotal;
        public DateTime StartTime {
            get { return startTime; }
            set { startTime = value; }
        }
        private DateTime endTime;

        public DateTime EndTime {
            get { return endTime; }
            set { endTime = value; }
        }
        public int Speed {
            get { return speed; }
            set { speed = value;

            playTimer.Interval = 1000 / speed;
            }
        }

        public PlaybackHelper(RMap map,IContainer c) {
            _map = map;
            playOverlay = map.FindOverlay("play");
            if (playOverlay == null) {
                playOverlay = new GMapOverlay(map, "play");
                map.Overlays.Add(playOverlay);
                playRoute = new GMapRoute(new List<GMap.NET.PointLatLng>(), "play");
                playRoute.Stroke.Color = Color.Red;
                playRoute.Stroke.Width = 3;
                playOverlay.Routes.Add(playRoute);


            } 

            car = new GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(0, 0));
            car.ToolTipMode = MarkerTooltipMode.Always;
            car.ToolTipText = "car";
            car.ToolTip.Format.Alignment = StringAlignment.Near;

            playOverlay.Markers.Add(car);

            queue_pos = new Queue<gps_position>();

            dataTimer = new Timer();
            dataTimer.Tick += new EventHandler(dataTimer_Tick);
            dataTimer.Interval = 1;
            playTimer = new Timer();
            playTimer.Tick += new EventHandler(playTimer_Tick);
            playTimer.Interval = 1000;
        }

        void playTimer_Tick(object sender, EventArgs e) {

            if (queue_pos.Count > 0) {
                gps_position pos = queue_pos.Dequeue();
                car.Position = new GMap.NET.PointLatLng(pos.lat, pos.lng);
                car.ToolTipText = string.Format("时间：{0}\n位置：{1}", pos.date, pos.c1);
                playRoute.Points.Add(car.Position);
                if (!_map.CurrentViewArea.Contains(car.Position))
                    _map.Position = car.Position;
                else {
                    _map.UpdateRouteLocalPosition(playRoute);
                    _map.UpdateMarkerLocalPosition(car);
                    _map.Refresh();
                }
            }
        }

        void dataTimer_Tick(object sender, EventArgs e) {
            dataTimer.Stop();
            string where =string.Format("where device_id={0} and date between '{1}' and '{2}' order by date",deviceid,startTime,endTime);
            Hashtable ht = new Hashtable();
            ht["limit"] = nLimit;
            ht["where"] = where;
            IList<gps_position> list = Client.ClientHelper.PlatformSqlMap.GetList<gps_position>("Selectgps_positionPage", ht);
            foreach (gps_position pos in list) {
                queue_pos.Enqueue(pos);
            }

            if (list.Count == nLimit) {
                startTime = list[nLimit - 1].date;
                if (playstate == PlayBackType.Play)
                    dataTimer.Start();
            } else {
                startTime = endTime;
            }

        }
        public void SetDevice(int id) {
            deviceid = id;
        }
        public void SetTime(DateTime start, DateTime end) {
            
        }
        public PlayBackType PlayState {
            get { return playstate; }
            set { playstate = value; }
        }
        public void Start() {
            if (playstate == PlayBackType.None) {
                //car = new GMapMarkerCar(new GMap.NET.PointLatLng(0, 0));
                //playOverlay.Markers.Add(car);
            }
            else if (playstate == PlayBackType.Pause) {
               
            } else if (playstate == PlayBackType.End ) {
                queue_pos.Clear();
                playRoute.Points.Clear();
                 car.Position = new GMap.NET.PointLatLng(0, 0);
               _map.RefreshOverlay("play");
            }
            

            playstate = PlayBackType.Play;
            dataTimer.Start();
            playTimer.Start();
        }
        public void End() {

            dataTimer.Stop();
            playTimer.Stop();
            playstate = PlayBackType.End;
        }
        public void Pause() {
            dataTimer.Stop();
            playTimer.Stop();
            playstate = PlayBackType.Pause;
        }
        public enum PlayBackType {
            None,
            Play,
            Pause,
            End
        }
        
    }
}
