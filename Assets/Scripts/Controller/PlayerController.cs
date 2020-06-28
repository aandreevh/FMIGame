using System;
using UnityEngine;
using World.Actors;
using World.Navigation;

namespace Controller
{
    [RequireComponent(typeof(Character))]
    public class PlayerController : MonoBehaviour
    {
        
        [SerializeField]
        private float speed = 1f;
        public float Speed => speed*Time.deltaTime;
        
        private Character Character { get; set; }
        private Interactor Interactor { get; set; }

        private void Awake()
        {
            Character = GetComponent<Character>();
            Interactor = GetComponent<Interactor>();
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
           Character.Interact();
        }

        private void MoveControl(Direction.Type direction)
        {
            Character.Walk(direction,Speed);
        }
    }
}