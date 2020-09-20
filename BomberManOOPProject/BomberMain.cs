using System;

namespace BomberManOOPProject
{
    class BomberMain
    {
        static void Main(string[] args)
        {
            Engine.Instance.Renderer = new ConsoleRenderer();
            Engine.Instance.UserInterface = new KeyboardInterface();
            Engine.Instance.AddObject(new DestructibleBlock(13, 3));
            Engine.Instance.AddObject(new DestructibleBlock(22, 3));
            Engine.Instance.AddObject(new DestructibleBlock(33, 3));
            Engine.Instance.AddObject(new IndestructibleBlock(22, 6));

            Engine.Instance.Run();

        }
    }
}
