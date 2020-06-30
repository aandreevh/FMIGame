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
            return CombineSync(CameraController.WaitTransition(3),
                CameraController.FadeScreenTransition(3));
        }

        private void FixedUpdate()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            HandleWalk();
            HandleInteraction();
        }

        private void HandleWalk()
        {
            if(Input.GetKey(KeyCode.W)) MoveControl(Direction.Type.Up);
            else if(Input.GetKey(KeyCode.S))MoveControl(Direction.Type.Down);
            else if(Input.GetKey(KeyCode.A))MoveControl(Direction.Type.Left);
            else if(Input.GetKey(KeyCode.D))MoveControl(Direction.Type.Right);
        }

        private void HandleInteraction()
        {
            if(Input.GetKey(KeyCode.Space)) InteractControl();
        }

        private void InteractControl()
        {
            Player.Interact();
        }

        private void MoveControl(Direction.Type direction)
        {
            Player.Walk(direction,Speed);
        }
    }
}