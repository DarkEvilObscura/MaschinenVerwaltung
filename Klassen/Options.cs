using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace MaschinenVerwaltung
{
    [Serializable]
    public class Options
    {
        [XmlIgnore]
        public Color ForeColor { get; set; }
        public Color BackgroundColor { get; set; }


        public Options()
        {
            
        }

        [XmlElement("ForeColor")]
        public int ForeColorARGB
        {
            get { return ForeColor.ToArgb(); }
            set { ForeColor = Color.FromArgb(value); }
        }

        [XmlElement("BackColor")]
        public int BackgroundColorARGB
        {
            get { return BackgroundColor.ToArgb(); }
            set { BackgroundColor = Color.FromArgb(value); }
        }

        public string SerializeOptions(Options options)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Options));
            using (StringWriter stringWriter = new StringWriter())
            {
                xml.Serialize(stringWriter, options);
                return Convert.ToString(stringWriter);
            }
        }

        public Options DeserializeOptions(string xmlOptions)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Options));
            return (Options)xml.Deserialize(new StringReader(xmlOptions));
        }

        //void SetColors(string options)
        //{
        //    if(string.IsNullOrEmpty(options))
        //    {
        //        this.foreColor = Color.Black;
        //        this.backgroundColor = Color.White;
        //    }
        //    else
        //    {
        //        string[] settings = options.Split(';');
        //        string[] foreColorSettings = settings[0].Split(',');
        //        string[] backgroundColorSettings = settings[1].Split(';');
        //        this.foreColor = Color.FromArgb(Int32.Parse(foreColorSettings[0]), Int32.Parse(foreColorSettings[1]), Int32.Parse(foreColorSettings[2]));
        //        this.backgroundColor = Color.FromArgb(Int32.Parse(backgroundColorSettings[0]), Int32.Parse(backgroundColorSettings[1]), Int32.Parse(backgroundColorSettings[2]));
        //    }
        //}

        //public Color ForeColor
        //{
        //    get
        //    {
        //        return this.foreColor;
        //    }
        //    set
        //    {
        //        this.foreColor = value;
        //    }
        //}

        //public Color BackgroundColor
        //{
        //    get
        //    {
        //        return this.backgroundColor;
        //    }
        //    set
        //    {
        //        this.backgroundColor = value;
        //    }
        //}
    }
}
