using System;
using System.Collections.Generic;
using System.Text;

namespace Ebada.Scgl.Gis {
    public class OperationInstances {

        private RMap mapcontrol;
        public OperationInstances(RMap map) {
            mapcontrol = map;
        }
        private OperationDistance distanceOperation;

        internal OperationDistance DistanceOperation {
            get {
                if (distanceOperation == null)
                    distanceOperation = new OperationDistance(mapcontrol);
                return distanceOperation;
            }
        }
        private OperationBase lineOperation;

        internal OperationBase LineOperation {
            get {
                if (lineOperation == null)
                    lineOperation = new OperationBase(mapcontrol);
                return lineOperation;
            }
        }
        private OperationPoint operationPoint;

        internal OperationPoint OperationPoint {
            get {
                if (operationPoint == null)
                    operationPoint = new OperationPoint(mapcontrol);
                return operationPoint;
            }
        }
    }
}
