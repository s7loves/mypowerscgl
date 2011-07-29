using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

namespace Ebada.Server.Host {
    partial class SCGLService : ServiceBase {
        public SCGLService() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {
            new ServerContainer();
        }

        protected override void OnStop() {
            ServerContainer.DefaultContainer.Dispose();
        }
    }
}
