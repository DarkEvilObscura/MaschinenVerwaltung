using System;
using System.Drawing;

namespace MaschinenVerwaltung
{
    partial class USettings
    {
        public int ScreenWidth { get; private set; }

        public USettings()
        {

        }

        public static Font GetSystemFontStyle()
        {
            FontFamily family = new FontFamily(UserSettings.Default["FontName"].ToString());
            float fontSize = (float)UserSettings.Default["FontSize"];
            FontStyle style = (FontStyle)UserSettings.Default["FontStyle"];

            return new Font(family, fontSize, style);
        }

        public static void SetSystemFontStyle(string fontName, FontStyle fontStyle, float fontSize)
        {
            UserSettings.Default["FontName"] = fontName;
            UserSettings.Default["FontStyle"] = (int)fontStyle;
            UserSettings.Default["FontSize"] = fontSize;

            UserSettings.Default.Save();
        }

        public static bool GetLogonStatus()
        {
            return Boolean.Parse(UserSettings.Default["StayLogon"].ToString());
        }

        public static void SetLogonStatus(bool login)
        {
            UserSettings.Default["StayLogon"] = login;
            UserSettings.Default.Save();
        }
    }
}
