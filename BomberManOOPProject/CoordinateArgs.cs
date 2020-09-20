using System;

namespace BomberManOOPProject
{
    class CoordinateArgs : EventArgs
    {
        private int left;
        private int top;

        public CoordinateArgs(int left, int top)
        {
            this.left = left;
            this.top = top;
        }

        public int Top
        {
            get
            {
                return this.top;
            }
        }

        public int Left
        {
            get
            {
                return this.left;
            }
        }
    }
}
