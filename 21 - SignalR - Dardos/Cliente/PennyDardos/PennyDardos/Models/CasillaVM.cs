using PennyDardos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PennyDardos.Models
{
    public class CasillaVM : clsVMBase
    {
        private string _image; //Image can be null, balloon or popped
        private string _background;
        public bool isBalloon { get; set; }
        public bool isPopped { get; set; }
        public string image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
                NotifyPropertyChanged("image");
            }
        }
        public string background
        {
            get
            {
                return _background;
            }

            set
            {
                _background = value;
                NotifyPropertyChanged("background");
            }
        }

        public CasillaVM()
        {
            isBalloon = false;
            isPopped = false;
            _image = "null";
        }

        public CasillaVM(bool isBalloon, bool isPopped, string background)
        {
            this.isBalloon = isBalloon;
            this.isPopped = isPopped;
            this._image = isBalloon ? (isPopped ? "popped" : "balloon") : "null";
            this._background = background;
        }

        public void popBalloon(string color)
        {
            this.isPopped = true;
            this.image = "popped";
            this.background = color;
        }
    }
}