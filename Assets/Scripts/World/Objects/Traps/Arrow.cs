using UnityEngine;
using World.Navigation;

namespace World.Objects.Traps
{
    [RequireComponent(typeof(Collider2D), typeof(Agent))]
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private Point target;

        private Agent Agent { get; set; }

        private void Awake()
        {
            Agent = GetComponent<Agent>();
            Agent.TargetPoint = target;
            UpdateRotation(target.Position - (Vector2) transform.position);
        }

        private void FixedUpdate()
        {
            UpdateRotation(Agent.UpdateAgent());
        }

        private void UpdateRotation(Vector2 vec)
        {
            var rot = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0, 0, rot);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
    }
}