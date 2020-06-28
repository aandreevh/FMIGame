using System.Collections;

namespace Controller.Cameras
{
    using Transition  = IEnumerator;
    public  partial class CameraController
    {
        private Transition TransitionStack { get; set; }
        
        public void LateUpdate()
        {
            TransitionStack.MoveNext();
        }
        
    }
}