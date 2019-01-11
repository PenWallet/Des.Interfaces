using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PennyDardos.Models
{
    public class Casilla
    {
        public bool isBalloon { get; set; }
        public bool isPopped;
        public string image { get; set; }  //Image can be null, balloon or popped

        public Casilla()
        {
            isBalloon = false;
            isPopped = false;
            image = "null";
        }

        public Casilla(bool isBalloon, bool isPopped)
        {
            this.isBalloon = isBalloon;
            this.isPopped = isPopped;
            this.image = isBalloon ? (isPopped ? "popped" : "balloon") : "null";
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
        }
    }
}