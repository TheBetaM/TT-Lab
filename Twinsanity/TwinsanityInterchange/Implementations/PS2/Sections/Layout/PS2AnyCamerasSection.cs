﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twinsanity.TwinsanityInterchange.Enumerations;
using Twinsanity.TwinsanityInterchange.Implementations.Base;

namespace Twinsanity.TwinsanityInterchange.Implementations.PS2.Sections
{
    public class PS2AnyCamerasSection : BaseTwinSection
    {
        public PS2AnyCamerasSection() : base()
        {
            defaultType = typeof(BaseTwinItem);
        }
    }
}
