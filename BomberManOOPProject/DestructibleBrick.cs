using System;

namespace BomberManOOPProject
{
    class DestructibleBrick : GameObject
    {
        private static readonly char[,] body = new char[,] { { '▓' } };

        public DestructibleBrick(int left, int right)
            : base(body, left, right)
        {
            this.Color = ConsoleColor.DarkGreen;
        }
    }
}
