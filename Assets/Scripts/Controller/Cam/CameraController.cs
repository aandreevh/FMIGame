using System.Collections;
using Controller.Cam.Transitions;
using UnityEngine;

namespace Controller.Cam
{
    using Transition = IEnumerator;

    [RequireComponent(typeof(Camera))]
    public partial class CameraController : MonoBehaviour
    {
        public Camera Camera { get; private set; }
        private Transition TransitionStack { get; set; }

        public void LateUpdate()
        {
            TransitionStack.MoveNext();
        }

        private void Awake()
        {
            Camera = GetComponent<Camera>();
            Reset();
        }
        public void Reset()
        {
            TransitionStack = this.IdentityTransition();
        }
    }
}