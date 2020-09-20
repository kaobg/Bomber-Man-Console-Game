using System;

namespace BomberManOOPProject
{
    class Player : GameObject, IMoveable
    {
        private static readonly char[,] body = new char[,] { { '☺' } };
        private MoveHandler moveHandler;
        

        public Player(int top, int left, MoveHandler moveHandler)
            : base(body, top, left)
        {
            this.Color = ConsoleColor.White;
            this.moveHandler = moveHandler;
        }

        public event EventHandler OnMove;
        public event EventHandler OnAction;

        public void HandleInput(object sender, EventArgs args)
        {
            KeyInfoArgs keyArgs = args as KeyInfoArgs;
            switch (keyArgs.Key)
            {
                case ConsoleKey.UpArrow:
                    Move(Direction.Up);
                    break;

                case ConsoleKey.DownArrow:
                    Move(Direction.Down);
                    break;

                case ConsoleKey.LeftArrow:
                    Move(Direction.Left);
                    break;

                case ConsoleKey.RightArrow:
                    Move(Direction.Right);

                    break;
                case ConsoleKey.Spacebar:
                    if (this.OnAction != null)
                    {
                        OnAction(this, new GameObjectArgs(new Bomb(this.Left, this.Top)));
                    }
                    // TO DO: bombs
                    break;
            }
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (moveHandler.IsValidMove(this.Left, this.Top - 1))
                    {
                        if (this.OnMove != null)
                        {
                            OnMove(this, new CoordinateArgs(this.Left, this.Top));
                        }
                        this.Top--;
                    }
                    break;

                case Direction.Down:
                    if (moveHandler.IsValidMove(this.Left, this.Top + this.Height))
                    {
                        if (this.OnMove != null)
                        {
                            OnMove(this, new CoordinateArgs(this.Left, this.Top));
                        }
                        this.Top++;
                    }
                    break;

                case Direction.Left:
                    if (moveHandler.IsValidMove(this.Left - 1, this.Top))
                    {
                        if (this.OnMove != null)
                        {
                            OnMove(this, new CoordinateArgs(this.Left, this.Top));
                        }
                        this.Left--;
                    }
                    break;

                case Direction.Right:
                    if (moveHandler.IsValidMove(this.Left + this.Width, this.Top))
                    {
                        if (this.OnMove != null)
                        {
                            OnMove(this, new CoordinateArgs(this.Left, this.Top));
                        }
                        this.Left++;
                    }
                    break;
            }

            if (this.OnMove != null)
            {
                OnMove(this, new GameObjectArgs(this));
            }
            
        }
    }
}
