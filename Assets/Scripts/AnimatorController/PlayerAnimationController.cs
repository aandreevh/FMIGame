using UnityEngine;
using World.Actors;
using World.Navigation;
using World.Objects;

namespace AnimatorController
{
    public class PlayerAnimationController : StateMachineBehaviour
    {
        public  const string HorizontalParam = "horizontal";
        public  const string VerticalParam = "vertical";
        public  const string MovingParam = "moving";
    
        private static readonly int Horizontal = Animator.StringToHash(HorizontalParam);
        private static readonly int Vertical = Animator.StringToHash(VerticalParam);
        private static readonly int Moving = Animator.StringToHash(MovingParam);
        private Player Player { get; set; }
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Player = animator.GetComponent<Player>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Player == null) return;
            var normal = GetDirectionNormal();
            animator.SetFloat(Horizontal,normal.x);
            animator.SetFloat(Vertical,normal.y);
            animator.SetBool(Moving,Player.HasWalked);
        }

        private Vector2 GetDirectionNormal()
        {
            return Player.LookingDirection.Normal();
        }

    }
}
