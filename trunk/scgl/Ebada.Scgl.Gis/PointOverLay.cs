﻿using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET;
using Ebada.Scgl.Model;
using Ebada.Scgl.Sbgl;
using System.Data;
using Ebada.Scgl.Gis.Markers;
namespace Ebada.Scgl.Gis {
    public class PointOverLay : GMapOverlay, IUpdateable {

        private GMapControl control;
        private bool allowEdit;

        
        public PointOverLay(GMapControl map, string lineCode)
            : base(map, lineCode) {
            control = map;
        }
        public bool AllowEdit {
            get { return allowEdit; }
            set { allowEdit = value; }
        }
        protected override void DrawRoutes(System.Drawing.Graphics g) {
            base.DrawRoutes(g);
        }
        public override void Render(System.Drawing.Graphics g) {
            base.Render(g);
        }
        public void Update(GMapMarker marker) {

        }
        public virtual void OnMarkerChanged(GMapMarker marker) {

        }
        public void ShowDialog(GMapMarker marker, bool canEdit) { 

            
        }
    }
}
