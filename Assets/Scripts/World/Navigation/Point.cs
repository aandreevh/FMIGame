using UnityEngine;

namespace World.Navigation
{
    public class Point : MonoBehaviour
    {
        [SerializeField]
        private Point previous;

        [SerializeField] 
        private Point next;

        public Point Previous => previous;
        public Point Next => next;

        public Vector2 Position => transform.position;

        private void OnDrawGizmos()
        {
            var position = transform.position;
            if (Next != null)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(position,Next.transform.position);
            }
            Gizmos.DrawSphere(position,0.2f);
        }
    }
}
