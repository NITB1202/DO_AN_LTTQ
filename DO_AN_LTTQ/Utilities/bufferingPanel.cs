﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_LTTQ.Utilities
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            // Bật Double Buffering cho Panel
            DoubleBuffered = true;
        }
    }
}
