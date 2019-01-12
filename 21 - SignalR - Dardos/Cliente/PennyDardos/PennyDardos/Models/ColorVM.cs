using PennyDardos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PennyDardos.Models
{
    public class ColorVM : clsVMBase
    {
        public string color { get; set; }
        private bool _isAvailable;
        public bool isAvailable
        {
            get
            {
                return _isAvailable;
            }
            
            set
            {
                _isAvailable = value;
                NotifyPropertyChanged("isAvailable");
            }
        }

        public ColorVM()
        {
            this.color = "";
            this.isAvailable = true;
        }

        public ColorVM(string color, bool isAvailable)
        {
            this.color = color;
            this.isAvailable = isAvailable;
        }
    }
}
