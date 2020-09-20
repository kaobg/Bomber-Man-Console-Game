using System;

namespace BomberManOOPProject
{
    class GameObjectArgs : EventArgs
    {
        private GameObject obj;

        public GameObjectArgs(GameObject obj)
        {
            this.obj = obj;
        }

        public GameObject GameObject
        {
            get
            {
                return this.obj;
            }
        }
    }
}
