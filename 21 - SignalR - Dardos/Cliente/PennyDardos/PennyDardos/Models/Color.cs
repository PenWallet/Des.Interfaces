using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PennyDardos.Models
{
    public class Color
    {
        public string color { get; set; }
        public bool isAvailable { get; set; }

        public Color()
        {
            this.color = "";
            this.isAvailable = true;
        }

        public Color(string color, bool isAvailable)
        {
            this.color = color;
            this.isAvailable = isAvailable;
        }
    }
}
