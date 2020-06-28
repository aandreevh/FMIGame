using System.Collections;
using System.Collections.Generic;

namespace Controller.Cameras
{
    using Transition  = IEnumerator;
    public partial class CameraController
    {
       
        public CameraController AddAsyncBefore(Transition transition)
        {
            TransitionStack = CombineAsync(transition, TransitionStack);
            return this;
        }

        public CameraController AddAsyncAfter(Transition transition)
        {
            TransitionStack = CombineAsync(TransitionStack, transition);
            return this;
        }

        public CameraController AddSyncBefore(Transition transition)
        {
            TransitionStack = CombineSync(transition, TransitionStack);
            return this;
        }

        public CameraController AddSyncAfter(Transition transition)
        {
            TransitionStack = CombineSync(TransitionStack, transition);
            return this;
        }
        
        public static Transition CombineAsync(Transition a, Transition b)
        {
            while (true)
            {
                var flagA = a.MoveNext();
                var flagB = b.MoveNext();
                if(flagA || flagB) yield return null;
                else yield break;
            }
        }

        public static Transition CombineSync(Transition a, Transition b)
        {
            while (a.MoveNext())
            {
                yield return null;
            }
            
            while (b.MoveNext())
            {
                yield return null;
            }
        }
    } 
}
