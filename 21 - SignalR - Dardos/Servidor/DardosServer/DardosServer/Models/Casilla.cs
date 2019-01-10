using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DardosServer.Models
{
    public class Casilla
    {
        public bool isBalloon { get;  set; }
        public bool isPopped;

        public Casilla()
        {
            isBalloon = false;
            isPopped = false;
        }

        public Casilla(bool isBalloon, bool isPopped)
        {
            this.isBalloon = isBalloon;
            this.isPopped = isPopped;
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