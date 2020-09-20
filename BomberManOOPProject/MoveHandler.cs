using System;
using System.Collections.Generic;

namespace BomberManOOPProject
{
    class MoveHandler
    {
        private int horizontalConstraint;
        private int verticalConstraint;
        private List<GameObject> objects;

        public MoveHandler(int horizontalConstraint, int verticalConstraint, List<GameObject> objects)
        {
            this.horizontalConstraint = horizontalConstraint;
            this.verticalConstraint = verticalConstraint;
            this.objects = objects;
        }

        public bool IsValidMove(int left, int top)
        {
            if (left >= 0 && left < this.horizontalConstraint &&
                top >= 0 && top < this.verticalConstraint)
            {
                foreach (GameObject obj in objects)
                {
                    if ((left >= obj.Left && left < obj.Left + obj.Width) &&
                        (top >= obj.Top && top < obj.Top + obj.Height))
                    {
                        int leftDifference = left - obj.Left;
                        int topDifference = top - obj.Top;
                        if (obj.Body[topDifference, leftDifference] != ' ')
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
