using System;

namespace BomberManOOPProject
{
    interface IMoveable
    {
        event EventHandler OnMove;
        void Move(Direction direction);
    }
}
