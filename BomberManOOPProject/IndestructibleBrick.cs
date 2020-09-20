using System;

namespace BomberManOOPProject
{
    class IndestructibleBrick : GameObject
    {
        private static readonly char[,] body = new char[,] { { '▓' } };
        
        public IndestructibleBrick(int left, int right)
            : base(body, left, right)
        {
            this.Color = ConsoleColor.DarkRed;
        }

    }
}
