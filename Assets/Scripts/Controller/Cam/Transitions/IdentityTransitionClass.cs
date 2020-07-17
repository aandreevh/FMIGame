using System;
using System.Collections;

namespace Controller.Cam.Transitions
{
    using Transition = IEnumerator;
    public static class IdentityTransitionClass
    {
        
        public static Transition IdentityTransition(this CameraController camera,Func<bool> condition = null)
        {
            condition = condition ?? (() => { return true; });
            while (condition()) yield return null;
        }
    }
}