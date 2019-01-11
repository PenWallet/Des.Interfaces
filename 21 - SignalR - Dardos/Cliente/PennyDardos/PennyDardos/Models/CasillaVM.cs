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
        public bool isBalloon { get; set; }
        public bool isPopped;
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

        public CasillaVM()
        {
            isBalloon = false;
            isPopped = false;
            _image = "null";
        }

        public CasillaVM(bool isBalloon, bool isPopped)
        {
            this.isBalloon = isBalloon;
            this.isPopped = isPopped;
            this._image = isBalloon ? (isPopped ? "popped" : "balloon") : "null";
        }

        public bool getIsPopped()
        {
            return this.isBalloon ? this.isPopped : false;
        }

        public void setIsPopped(bool isPopped)
        {
            this.isPopped = isPopped;
        }

        public void popBalloon()
        {
            this.isPopped = true;
            this.image = "popped";
        }
    }
}