using Controller.Cam;
using Controller.Cam.Transitions;
using UnityEngine;
using World.Actors;
using World.Navigation;

namespace Controller
{
    [RequireComponent(typeof(Player))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField] private Transform lighting;
        [SerializeField] private float speed = 1f;

        public float Speed => speed * Time.deltaTime;
        public CameraController CameraController => cameraController;
        public Transform Lighting => lighting;

        private Player Player { get; set; }
        private Interactor Interactor { get; set; }

        private void Awake()
        {
            Player = GetComponent<Player>();
            Interactor = GetComponent<Interactor>();
        }

        private void Start()
        {
            CameraFollow();
        }

        private void CameraFollow()
        {
            CameraController.AddSyncBefore(CameraController.FollowTransition(transform));
        }

        private void FixedUpdate()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            HandleWalk();
            HandleLighting();
            HandleInteraction();
        }

        private void HandleLighting()
        {
            LookAtMouse(Lighting);
        }

        private void LookAtMouse(Transform target, float rotationOffset = 90)
        {
            var diff = CameraController.Camera.ScreenToWorldPoint(Input.mousePosition) - target.position;

            var rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - rotationOffset;
            target.rotation = Quaternion.Euler(Vector3.forward * rot);
        }

        private void HandleWalk()
        {
            if (Input.GetKey(KeyCode.W)) MoveControl(Direction.Up);
            else if (Input.GetKey(KeyCode.S)) MoveControl(Direction.Down);
            else if (Input.GetKey(KeyCode.A)) MoveControl(Direction.Left);
            else if (Input.GetKey(KeyCode.D)) MoveControl(Direction.Right);
        }

        private void HandleInteraction()
        {
            if (Input.GetKey(KeyCode.Space)) InteractControl();
        }

        private void InteractControl()
        {
            Player.Interact();
        }

        private void MoveControl(Direction direction)
        {
            Player.Walk(direction, Speed);
        }
    }
}