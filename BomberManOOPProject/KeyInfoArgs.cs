using System;

namespace BomberManOOPProject
{
    class KeyInfoArgs : EventArgs
    {
        private ConsoleKey keyInfo;

        public KeyInfoArgs(ConsoleKey key)
            : base()
        {
            this.keyInfo = key;
        }

        public ConsoleKey Key
        {
            get
            {
                return this.keyInfo;
            }
        }
    }
}
