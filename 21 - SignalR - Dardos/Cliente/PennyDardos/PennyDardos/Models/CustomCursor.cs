using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace PennyDardos.Models
{
    public class CustomCursor
    {
        public CoreCursor cursor { get; set; }
        public string name { get; set; }
        public string image { get; set; }

        public CustomCursor(CoreCursor cursor, string name, string image)
        {
            this.cursor = cursor;
            this.name = name;
            this.image = image;
        }
    }
}
