using System;
using System.Collections.Generic;

namespace BomberManOOPProject
{
    class ExplosionHandler
    {
        public void UpdateBlast(object sender, EventArgs e)
        {
            Explosion exp = (Explosion)sender;

            if (exp.Top - exp.CurrentRadius >= 0 && !exp.StopUp)
            {
                Console.SetCursorPosition(exp.Left, exp.Top - exp.CurrentRadius);
                Console.Write("^");
                exp.CleanUpCoords.Add(new CoordinateArgs(exp.Left, exp.Top - exp.CurrentRadius));
            }
            if (exp.Left + exp.CurrentRadius < Console.WindowWidth && !exp.StopRight)
            {
                Console.SetCursorPosition(exp.Left + exp.CurrentRadius, exp.Top);
                Console.Write(">");
                exp.CleanUpCoords.Add(new CoordinateArgs(exp.Left + exp.CurrentRadius, exp.Top));
            }
            if (exp.Top + exp.CurrentRadius < Console.WindowHeight && !exp.StopDown)
            {
                Console.SetCursorPosition(exp.Left, exp.Top + exp.CurrentRadius);
                Console.Write("v");
                exp.CleanUpCoords.Add(new CoordinateArgs(exp.Left, exp.Top + exp.CurrentRadius));
            }
            if (exp.Left - exp.CurrentRadius >= 0 && !exp.StopLeft)
            {
                Console.SetCursorPosition(exp.Left - exp.CurrentRadius, exp.Top);
                Console.Write("<");
                exp.CleanUpCoords.Add(new CoordinateArgs(exp.Left - exp.CurrentRadius, exp.Top));
            }
        }

        public void Collide(Explosion exp, List<GameObject> allObjects)
        {
            foreach (GameObject obj in allObjects)
            {
                 if ((obj.Top == exp.Top - exp.CurrentRadius && obj.Left == exp.Left)
                     || (obj.Top == exp.Top && obj.Left == exp.Left + exp.CurrentRadius)
                     || (obj.Top == exp.Top + exp.CurrentRadius && obj.Left == exp.Left)
                     || (obj.Top == exp.Top && obj.Left == exp.Left - exp.CurrentRadius)
                     )
                 {
                     if (!(obj is IndestructibleBrick))
                     {
                         obj.IsDestroyed = true;
                     }
                     else
                     {
                         if (obj.Top == exp.Top - exp.CurrentRadius && obj.Left == exp.Left)
                         {
                             exp.StopUp = true;
                         }
                         else if (obj.Top == exp.Top && obj.Left == exp.Left + exp.CurrentRadius)
                         {
                             exp.StopRight = true;
                         }
                         else if (obj.Top == exp.Top + exp.CurrentRadius && obj.Left == exp.Left)
                         {
                             exp.StopDown = true;
                         }
                         else if (obj.Top == exp.Top && obj.Left == exp.Left - exp.CurrentRadius)
                         {
                             exp.StopLeft = true;
                         }   
                     }

                     
                 }
            }
            allObjects.RemoveAll(obj => obj.IsDestroyed);
        }
    }
}
