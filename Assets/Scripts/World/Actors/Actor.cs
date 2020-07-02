using UnityEngine;

namespace World.Actors
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Actor : MonoBehaviour
    {
        [Header("Actor")]
        [SerializeField] private Vector2 motion;
        
        public Vector2 Position => Body.position;

        public Vector2 NextPosition => Position + Motion;
        public Rigidbody2D Body { get;  private set;  }

        public Vector2 Motion
        {
            get => motion;
            private set => motion = value;
        }

        public bool HasMoved { get; private set; }

        protected virtual void Awake()
        {
            Body = GetComponent<Rigidbody2D>();
        }

        public Vector2 MoveToPosition(Vector2 pos, float speed)
        {
            var distance = speed * Time.deltaTime;
            var deltaVec = pos-NextPosition;
            if (deltaVec.sqrMagnitude > distance) {
                deltaVec = distance*deltaVec.normalized ;
            }
            Move(deltaVec);
            
            return deltaVec;
        }
        public void Move(Vector2 motionVector)
        {
            Motion += motionVector;
        }
        private void FixedUpdate()
        {
            UpdateMotion();
        }

        protected virtual void UpdateMotion()
        {
            if (Motion.magnitude > 0)
            {
                Body.MovePosition(Position + Motion);
                Motion = Vector2.zero;
                HasMoved = true;
            }
            else HasMoved = false;

        }
        

    }
}