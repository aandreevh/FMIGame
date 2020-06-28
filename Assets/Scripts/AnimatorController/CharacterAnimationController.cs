using UnityEngine;
using World.Actors;
using World.Navigation;
using World.Objects;

namespace AnimatorController
{
    public class CharacterAnimationController : StateMachineBehaviour
    {
        public  const string HorizontalParam = "horizontal";
        public  const string VerticalParam = "vertical";
        public  const string MovingParam = "moving";
    
        private static readonly int Horizontal = Animator.StringToHash(HorizontalParam);
        private static readonly int Vertical = Animator.StringToHash(VerticalParam);
        private static readonly int Moving = Animator.StringToHash(MovingParam);
        private Character Character { get; set; }
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Character = animator.GetComponent<Character>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Character == null) return;
            var normal = GetDirectionNormal();
            animator.SetFloat(Horizontal,normal.x);
            animator.SetFloat(Vertical,normal.y);
            animator.SetBool(Moving,Character.HasWalked);
        }

        private Vector2 GetDirectionNormal()
        {
            return Direction.NormalFromDirection(Character.LookingDirection);
        }

    }
}
