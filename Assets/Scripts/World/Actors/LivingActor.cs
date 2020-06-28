using UnityEngine;

namespace World.Actors
{
    public class LivingActor : MonoBehaviour
    {
        protected const float ACTOR_HEALTH = 100f;
        protected const float ACTOR_DEAD = 0f;
        
        public float currentHealth = ACTOR_HEALTH;
        public float maximumHealth = ACTOR_HEALTH;

        public virtual void OnHit(float damage) {}

        protected virtual void OnDeath() {}

    }
}