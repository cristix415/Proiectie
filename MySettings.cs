using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ProiectareCantari
{
    class MySettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue("Black")]
        public Color BackgroundColor
        {
            get
            {
                return ((Color)this["BackgroundColor"]);
            }
            set
            {
                this["BackgroundColor"] = (Color)value;
            }
        }
        [UserScopedSetting()]
        [DefaultSettingValue("white")]
        public Color CuloareText
        {
            get
            {
                return ((Color)this["CuloareText"]);
            }
            set
            {
                this["CuloareText"] = (Color)value;
            }
        }
    }
}
