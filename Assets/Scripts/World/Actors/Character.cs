using Signals.Emitters;
using UnityEngine;
using World.Actors;
using World.Navigation;

namespace World.Actors
{
    
    [RequireComponent(typeof(Interactor))]
    public class Character : Actor
    {
   
        [Header("Character")]
        [SerializeField]
        private Direction.Type lookingDirection;

        public bool HasWalked { get; private set; }
        private bool walked = false;
       
        public Direction.Type LookingDirection
        {
            get => lookingDirection;
            set => lookingDirection = value;
        }
        
        public Interactor Interactor { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Interactor = GetComponent<Interactor>();
        }

        public void Walk(Direction.Type direction, float amount)
        {
            LookingDirection = direction;
            walked = true;
            Move(amount* Direction.NormalFromDirection(direction));
        }

        public void Interact()
        {
            Interactor.Interact(Direction.NormalFromDirection(LookingDirection));
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
