using System;
using System.Text;

namespace BomberManOOPProject
{
    abstract class GameObject : IRenderable
    {
        private char[,] body;
        private int left;
        private int top;
        private bool isDestroyed;
        private ConsoleColor color;

        public GameObject(char[,] body, int left, int top)
        {
            this.body = body;
            this.left = left;
            this.top = top;
            this.isDestroyed = false;
        }
        
        public bool IsDestroyed
        {
            get
            {
                return this.isDestroyed;
            }
            set
            {
                this.isDestroyed = value;
            }
        }

        public int Top
        {
            get
            {
                return this.top;
            }
            set
            {
                this.top = value;
            }
        }

        public int Left
        {
            get
            {
                return this.left;
            }
            set
            {
                this.left = value;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public int Height
        {
            get
            {
                return body.GetLength(0);
            }
        }

        public int Width
        {
            get
            {
                return body.GetLength(1);
            }
        }

        public char[,] Body
        {
            get 
            {
                return this.body;
            }
        }
    }
}
