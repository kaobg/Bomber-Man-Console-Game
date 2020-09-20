using System;

namespace BomberManOOPProject
{
    class KeyboardInterface : IUserInterface
    {
        public event EventHandler OnKeyPressed;
        
        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);
                if (this.OnKeyPressed != null)
                {
                    this.OnKeyPressed(this, new KeyInfoArgs(info.Key));
                }
            }
        }

    }
}
