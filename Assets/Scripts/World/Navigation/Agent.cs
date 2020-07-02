using UnityEngine;
using World.Actors;
using World.Objects;

namespace World.Navigation
{
    [RequireComponent(typeof(Actor))]
    public class Agent : MonoBehaviour
    {
        public enum TraverseDirection
        {
            Forward,Backward
        }
        
        [Header("Agent")]
        [SerializeField] private float speed=1;
        [SerializeField] private Point targetPoint;
        [SerializeField, HideInInspector] public TraverseDirection direction = TraverseDirection.Forward;
        public float Speed => speed*Time.deltaTime;
        
        private TraverseDirection Direction
        {
            get => direction;
            set => direction = value;
        }

        public Point TargetPoint
        {
            get => targetPoint;
            private set => targetPoint = value;
        }
        public Actor Actor { get; private set; }

        private void Awake()
        {
            Actor = GetComponent<Actor>();
        }

        public Vector2 UpdateAgent()
        {
            if(!TargetPoint) return Vector2.zero;
            Actor.MoveToPosition(TargetPoint.Position, Speed);
            var actualMovement = TargetPoint.Position - Actor.NextPosition;
            if (actualMovement.sqrMagnitude < 0.01f)
            {
                UpdateNextTargetPoint();
            }
            return actualMovement;
        }
        private void UpdateNextTargetPoint()
        {
            if (Direction == TraverseDirection.Forward)
            {
                if (!TargetPoint.Next)
                {
                    Direction = TraverseDirection.Backward;
                }
                else TargetPoint = TargetPoint.Next;
            }
            else if (Direction == TraverseDirection.Backward)
            {
                if (!TargetPoint.Previous)
                {
                    Direction = TraverseDirection.Forward;
                }
                else TargetPoint = TargetPoint.Previous;
            }
        }
    }
}