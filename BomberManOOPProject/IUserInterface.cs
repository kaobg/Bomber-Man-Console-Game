using System;

namespace BomberManOOPProject
{
    interface IUserInterface
    {
        event EventHandler OnKeyPressed;
        void ProcessInput();
    }
}
