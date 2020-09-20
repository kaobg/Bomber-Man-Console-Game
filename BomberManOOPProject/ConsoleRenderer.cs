using System;
using System.Collections.Generic;

namespace BomberManOOPProject
{
    class ConsoleRenderer : IRenderer
    {

        public ConsoleRenderer()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.CursorVisible = false;
            Console.Title = "Bomber man";
        }

       

        public void RenderObject(GameObject obj)
        {
            Console.ForegroundColor = obj.Color;
            int left = obj.Left;
            int top = obj.Top;

            for (int row = 0; row < obj.Height; row++)
            {
                for (int col = 0; col < obj.Width; col++)
                {
                    Console.SetCursorPosition(left + col, top + row);
                    Console.Write(obj.Body[row, col]);
                }
            }
        }

        public void RenderObject(object sender, EventArgs e)
        {
            GameObjectArgs objArgs = e as GameObjectArgs;
            if (objArgs != null)
            {
                RenderObject(objArgs.GameObject);
            }
        }

        public void CleanUp(object sender, EventArgs e)
        {
            CoordinateArgs args = e as CoordinateArgs;
            if (args != null)
            {
                Console.SetCursorPosition(args.Left, args.Top);
                Console.Write(' ');
            }
        }
    }
}
