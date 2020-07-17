using Controller;
using Items;
using UnityEngine;
using World.Navigation;

namespace World.Actors
{
    [RequireComponent(typeof(Interactor),
        typeof(ItemPicker),
        typeof(PlayerController))]
    public class Player : Actor
    {
        [Header("Player")] [SerializeField] private Direction lookingDirection;

        private bool walkedSynchronizer;

        public bool HasWalked { get; private set; }

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
            walkedSynchronizer = true;
            Move(amount * direction.Normal());
        }

        public void Interact()
        {
            Interactor.Interact(LookingDirection.Normal());
        }

        protected override void UpdateMotion()
        {
            base.UpdateMotion();
            if (HasMoved && walkedSynchronizer)
            {
                HasWalked = true;
                walkedSynchronizer = false;
            }
            else
            {
                HasWalked = false;
            }
        }
    }
}