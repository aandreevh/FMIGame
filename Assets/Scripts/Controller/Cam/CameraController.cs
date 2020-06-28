using System.Collections;
using UnityEngine;

namespace Controller.Cam
{
    using Transition = IEnumerator;
    [RequireComponent(typeof(Camera))]
    public partial class CameraController : MonoBehaviour
    {
        public Camera Camera { get; set; }
        
        
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
        
    }
}