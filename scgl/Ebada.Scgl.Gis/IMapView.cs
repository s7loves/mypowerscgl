﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ebada.Scgl.Gis {
    internal interface IMapView {
        /// <summary>
        /// 缩小
        /// </summary>
        void Zoomin();
        /// <summary>
        /// 放大
        /// </summary>
        void Zoomout();
        /// <summary>
        /// 漫游
        /// </summary>
        void Roam();
        /// <summary>
        /// 飞行模式
        /// </summary>
        void Fly();
        /// <summary>
        /// 测距
        /// </summary>
        void Distance();
        /// <summary>
        /// 全景
        /// </summary>
        void FullView();

    }
}
