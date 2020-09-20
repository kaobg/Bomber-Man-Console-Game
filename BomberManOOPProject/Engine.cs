using System;
using System.Collections.Generic;

namespace BomberManOOPProject
{
    class Engine
    {
        private IRenderer renderer;
        private IUserInterface userInterface;
        private List<GameObject> staticObjects;
        private List<GameObject> bombs;
        private Player player;
        private int sleepTime = 150;
        private static Engine instance;
        private MoveHandler moveHandler;
        private ExplosionHandler expHandler;
        private List<Explosion> explosions;
        private static int bombLimit = 3;

        static Engine()
        {
            instance = new Engine();
        }

        private Engine() 
        {
            this.staticObjects = new List<GameObject>();
            this.bombs = new List<GameObject>();
            this.moveHandler = new MoveHandler(Console.WindowWidth, Console.WindowHeight, staticObjects);
            this.expHandler = new ExplosionHandler();
            this.explosions = new List<Explosion>();
            this.player = new Player(0, 0, moveHandler);
        }

        public static Engine Instance
        {
            get
            {
                return instance;
            }
        }

        public IRenderer Renderer
        {
            get
            {
                return this.renderer;
            }
            set
            {
                this.renderer = value;
                this.player.OnMove += renderer.CleanUp;
                this.player.OnMove += ((ConsoleRenderer)renderer).RenderObject;
                this.player.OnAction += OnActionPressed;
            }
        }

        public void OnActionPressed(object sender, EventArgs e) // used to add bombs to the list
        {
            GameObjectArgs args = e as GameObjectArgs;
            if (args != null)
            {
                AddObject(args.GameObject);
            }
        }

        public IUserInterface UserInterface
        {
            get
            {
                return this.userInterface;
            }
            set
            {
                this.userInterface = value;
                this.userInterface.OnKeyPressed += player.HandleInput;
            }
        }

        public int SleepTime
        {
            get
            {
                return this.sleepTime;
            }
            set
            {
                this.sleepTime = value;
            }
        }

        
        public void AddObject(GameObject obj)
        {
            if (obj is Bomb)
            {
                if (bombs.Count < bombLimit)
                {
                    Bomb bomb = obj as Bomb;
                    bomb.OnExplode += CatchExplosion;
                    this.bombs.Add(bomb);
                    this.staticObjects.Add(bomb);
                }
            }
            else if (obj is IndestructibleBlock)
            {
                this.staticObjects.Add(new IndestructibleBrick(obj.Left, obj.Top));
                this.staticObjects.Add(new IndestructibleBrick(obj.Left+1, obj.Top));
                this.staticObjects.Add(new IndestructibleBrick(obj.Left + 2, obj.Top));
                this.staticObjects.Add(new IndestructibleBrick(obj.Left, obj.Top+1));
                this.staticObjects.Add(new IndestructibleBrick(obj.Left+1, obj.Top+1));
                this.staticObjects.Add(new IndestructibleBrick(obj.Left + 2, obj.Top + 1));

            }
            else if (obj is DestructibleBlock)
            {
                this.staticObjects.Add(new DestructibleBrick(obj.Left, obj.Top));
                this.staticObjects.Add(new DestructibleBrick(obj.Left + 1, obj.Top));
                this.staticObjects.Add(new DestructibleBrick(obj.Left + 2, obj.Top));
                this.staticObjects.Add(new DestructibleBrick(obj.Left, obj.Top + 1));
                this.staticObjects.Add(new DestructibleBrick(obj.Left + 1, obj.Top + 1));
                this.staticObjects.Add(new DestructibleBrick(obj.Left + 2, obj.Top + 1));
            }
            else
            {
                this.staticObjects.Add(obj);
            }
        }

        public void CatchExplosion(object sender, EventArgs e)
        {
            Bomb bomb = (Bomb)sender;
            bomb.IsDestroyed = true;
            Explosion newExp = new Explosion(bomb.Left, bomb.Top);
            newExp.OnUpdate += delegate(object _sender, EventArgs _e)
            {
                expHandler.Collide((Explosion)_sender, staticObjects);
            };
            newExp.OnUpdate += expHandler.UpdateBlast;
            
            newExp.OnDissappear += delegate(object _sender, EventArgs _e)
            {
                Explosion exp = (Explosion)_sender;
                foreach (CoordinateArgs coords in exp.CleanUpCoords)
                {
                    renderer.CleanUp(this, coords);
                }
            };
            this.explosions.Add(newExp);
        }


        public void Run()
        {
            foreach (GameObject obj in this.staticObjects)
            {
                renderer.RenderObject(obj);
            }
            renderer.RenderObject(player);

            while (true)
            {
                foreach (Bomb bomb in bombs)
                {
                    bomb.Update();
                    if (bomb.IsDestroyed)
                    {
                        renderer.CleanUp(this, new CoordinateArgs(bomb.Left, bomb.Top));
                    }
                    else
                    {
                        renderer.RenderObject(bomb);
                    }
                }

                bombs.RemoveAll(bomb => bomb.IsDestroyed);
                staticObjects.RemoveAll(bomb => bomb.IsDestroyed);

                foreach (Explosion exp in explosions)
                {
                    exp.Update();
                }
                explosions.RemoveAll(exp => exp.IsDestroyed);
                
                System.Threading.Thread.Sleep(sleepTime);
                this.userInterface.ProcessInput();
            }
        }
    }
}
