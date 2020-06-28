using UnityEngine;

namespace World.Actors
{
    public class LivingCharacter : LivingActor
    {
        public override void OnHit(float damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maximumHealth);

            if (currentHealth == ACTOR_DEAD) OnDeath();
        }

        protected override void OnDeath()
        {
        }
    }
}