using System;
using System.Collections.Generic;

namespace BomberManOOPProject
{
    class Explosion
    {
        private int left;
        private int top;
        private int currentRadius;
        private static int radius = 3;
        private bool isDestroyed;
        private bool stopUp;
        private bool stopRight;
        private bool stopDown;
        private bool stopLeft;
        public event EventHandler OnUpdate;
        public event EventHandler OnDissappear;
        private List<CoordinateArgs> cleanUpCoords;

        

        public Explosion(int left, int top)
        {
            this.left = left;
            this.top = top;
            this.currentRadius = 0;
            this.cleanUpCoords = new List<CoordinateArgs>();
        }

        public int Left
        {
            get
            {
                return this.left;
            }
        }

        public int Top
        {
            get
            {
                return this.top;
            }
        }

        public int CurrentRadius
        {
            get
            {
                return this.currentRadius;
            }
            set
            {
                currentRadius = value;
            }
        }

        public int RadiusLimit
        {
            get
            {
                return radius;
            }
        }

        public bool IsDestroyed
        {
            get
            {
                return this.isDestroyed;
            }
        }

        public bool StopUp
        {
            get { return stopUp; }
            set { stopUp = value; }
        }

        public bool StopRight
        {
            get { return stopRight; }
            set { stopRight = value; }
        }

        public bool StopDown
        {
            get { return stopDown; }
            set { stopDown = value; }
        }

        public bool StopLeft
        {
            get { return stopLeft; }
            set { stopLeft = value; }
        }

        public List<CoordinateArgs> CleanUpCoords
        {
            get { return cleanUpCoords; }
            set { cleanUpCoords = value; }
        }

        public void Update()
        {
            this.currentRadius++;
            if (this.currentRadius <= radius)
            {
                if (OnUpdate != null)
                {
                    OnUpdate(this, new EventArgs());
                }
            }
            else
            {
                this.isDestroyed = true;
                if (OnDissappear != null)
                {
                    OnDissappear(this, new EventArgs());
                }
            }
        }

    }
}
