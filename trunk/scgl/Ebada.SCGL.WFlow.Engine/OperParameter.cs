using System;
using System.Collections.Generic;
using System.Text;

namespace Ebada.SCGL.WFlow.Engine
{
    public  class OperParameter
    {
        private   string operContent;
        private   string operRule;
        private int operRelation;
        private int operType;
        private string operContentText;
        private bool isJumpSelf;

        public OperParameter()
        {
 
        }

        public string OperContent
        {
            get
            {
               return operContent;
            }
            set
            {
                operContent = value;
            }
        }

        public string OperContenText
        {
            get
            {
                return operContentText;
            }
            set
            {
                operContentText = value;
            }
        }

        public int OperRelation
        {
            get
            {
                return operRelation;
            }
            set
            {
                operRelation = value;
            }
        }

        public string  OperRule
        {
            get
            {
                return operRule;
            }
            set
            {
                operRule = value;
            }
        }

        public int OperType
        {
            get
            {
                return operType;
            }
            set
            {
                operType = value;
            }
        }

        public bool IsJumpSelf
        {
            get
            {
                return isJumpSelf;
            }
            set
            {
                isJumpSelf = value;
            }
        }
    }
}
