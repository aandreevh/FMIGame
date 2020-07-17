using System;
using System.Collections;
using UnityEngine;

namespace Controller.Cam.Transitions
{
    using Transition = IEnumerator;
    
    public static class FollowTransitionClass
    {
        
        public static Transition FollowTransition(this CameraController controller,
            Transform target, Func<bool> condition = null)
        {
            condition = condition ?? (() => { return true; });

            var transformComponent = controller.transform;
            while (condition())
            {
                transformComponent.position = new Vector3(target.position.x, target.position.y, 
                    controller.transform.position.z);
                
                yield return null;
            }
        }

    }
}