using System;
using System.Collections;
using System.Collections.Generic;
using Controller.Cam;
using UnityEditor;
using UnityEngine;
using World.Actors;
using World.Navigation;
using static Controller.Cam.CameraController;
namespace Controller
{
    [RequireComponent(typeof(Player))]
    public class PlayerController : MonoBehaviour
    {
        
        [SerializeField]
        private float speed = 1f;
        public float Speed => speed*Time.deltaTime;

        [SerializeField] private CameraController cameraController;
        public CameraController CameraController => cameraController;

        [SerializeField] private Transform lighting;
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

            CameraController
                .AddSyncBefore(CameraController.FollowTransition(transform));
        }

        private IEnumerator WaitAndFade()
        {
            return CombineSync(CameraController.WaitTransition(1),
                CameraController.FadeScreenTransition(10));
        }

        private void FixedUpdate()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            HandleWalk();
            HandeLighting();
            HandleInteraction();
        }

        private void HandeLighting()
        { 
            var mousePosition = Input.mousePosition;
           var diff=  CameraController.Camera.ScreenToWorldPoint(mousePosition) - Lighting.position;

           float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg-90;
           Lighting.rotation = Quaternion.Euler(Vector3.forward * rot);
        }

        private void HandleWalk()
        {
            if(Input.GetKey(KeyCode.W)) MoveControl(Direction.Up);
            else if(Input.GetKey(KeyCode.S))MoveControl(Direction.Down);
            else if(Input.GetKey(KeyCode.A))MoveControl(Direction.Left);
            else if(Input.GetKey(KeyCode.D))MoveControl(Direction.Right);
        }

        private void HandleInteraction()
        {
            if(Input.GetKey(KeyCode.Space)) InteractControl();
        }

        private void InteractControl()
        {
            Player.Interact();
        }

        private void MoveControl(Direction direction)
        {
            Player.Walk(direction,Speed);
        }
        
    }
}