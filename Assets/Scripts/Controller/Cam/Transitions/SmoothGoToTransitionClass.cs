using System.Collections;
using UnityEngine;

namespace Controller.Cam.Transitions
{
    using Transition = IEnumerator;
    public static class SmoothGoToTransitionClass
    {
        public static Transition SmoothGoToTransition(this CameraController controller,
            Vector2 target, float speed)
        {
            var transformComponent = controller.transform;
            while (true)
            {
                var deltaSpeed = speed * Time.deltaTime;
                var position = (Vector2) controller.transform.position;

                if (Vector2.Distance(target, position) < deltaSpeed)
                {
                    transformComponent.position = new Vector3(target.x, target.y, transformComponent.position.z);
                    yield break;
                }

                var direction = (target - position).normalized;
                var deltaMovement = direction * deltaSpeed;

                transformComponent.position = new Vector3(position.x + deltaMovement.x,
                    position.y + deltaMovement.y,
                    transformComponent.position.z);
                yield return null;
            }
        }

    }
}