﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _63CNTT5N2.Library
{
    public class XMessage
    {
        public string TypeMsg { get; set; }

        public string Msg { get; set; }
        public XMessage()
        {

        }

        public XMessage(string TypeMsg, string Msg)
        {
            this.TypeMsg = TypeMsg;
            this.Msg = Msg;
        }
    }
}