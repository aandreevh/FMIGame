using System.Runtime.CompilerServices;
using Controller;
using Items;
using Signals.Emitters;
using UnityEngine;
using World.Actors;
using World.Navigation;

namespace World.Actors
{
    [RequireComponent(typeof(Interactor),
        typeof(ItemPicker),
    typeof(PlayerController))]
    public class Player : Actor
    {
   
        [Header("Player")]
        [SerializeField]
        private Direction lookingDirection;

        public bool HasWalked { get; private set; }
        private bool walked = false;
       
        public Direction LookingDirection
        {
            get => lookingDirection;
            private set => lookingDirection = value;
        }
        
        public Interactor Interactor { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Interactor = GetComponent<Interactor>();
        }

        public void Walk(Direction direction, float amount)
        {
            LookingDirection = direction;
            walked = true;
            Move(amount* direction.Normal());
        }

        public void Interact()
        {
            Interactor.Interact(LookingDirection.Normal());
        }

        protected override void UpdateMotion()
        {
            base.UpdateMotion();
            if (HasMoved && walked)
            {
                HasWalked = true;
                walked = false;
            }
            else HasWalked = false;
        }
    }
}
