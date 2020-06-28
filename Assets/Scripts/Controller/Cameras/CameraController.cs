using System.Collections;
using UnityEngine;

namespace Controller.Cameras
{
    [RequireComponent(typeof(Camera))]
    public partial class CameraController : MonoBehaviour
    {
        public Camera Camera { get; set; }

        private void Awake()
        {
            Camera = GetComponent<Camera>();
        }
        
    }
}