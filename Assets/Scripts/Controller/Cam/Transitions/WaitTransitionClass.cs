using System.Collections;
using UnityEngine;

namespace Controller.Cam.Transitions
{
    using Transition = IEnumerator;
    
    public static class WaitTransitionClass
    {
        public static Transition WaitTransition(this CameraController _,
            float timeout)
        {
            var time = timeout;
            while (true)
            {
                time -= Time.deltaTime;
                if (time <= 0) yield break;

                yield return null;
            }
        }

    }
}