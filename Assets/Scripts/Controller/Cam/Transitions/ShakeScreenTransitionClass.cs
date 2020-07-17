using System.Collections;
using UnityEngine;

namespace Controller.Cam.Transitions
{
    using Transition = IEnumerator;
    public static class ShakeScreenTransitionClass
    {
     
        public static Transition ShakeScreenTransition(this CameraController controller,float amount, 
            float time, bool autoRevert = false)
        {
            var lastTransition = Vector3.zero;
            var cameraTansform = controller.Camera.transform;

            while (true)
            {
                time -= Time.deltaTime;

                var position = cameraTansform.position;
                if (autoRevert) position -= lastTransition;

                lastTransition = (Vector3) Random.insideUnitCircle * amount;

                position += lastTransition;
                cameraTansform.position = position;
                if (time <= 0) yield break;

                yield return null;
            }
        }


    }
}