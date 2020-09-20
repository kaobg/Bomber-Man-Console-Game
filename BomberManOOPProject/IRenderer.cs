using System;

namespace BomberManOOPProject
{
    interface IRenderer
    {
        void RenderObject(GameObject obj);
        void CleanUp(object sender, EventArgs e);
    }
}
