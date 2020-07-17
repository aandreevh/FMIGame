using UnityEngine;
using World.Actors;
using World.Navigation;

namespace AnimatorController
{
    public class PlayerAnimationController : StateMachineBehaviour
    {
        [SerializeField] private string horizontalParam = "horizontal";
        [SerializeField] private string movingParam = "moving";
        [SerializeField] private string verticalParam = "vertical";

        private int HorizontalKey => Animator.StringToHash(horizontalParam);
        private int VerticalKey => Animator.StringToHash(verticalParam);
        private int MovingKey => Animator.StringToHash(movingParam);
        private Player Player { get; set; }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Player = animator.GetComponent<Player>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Player == null) return;

            var normal = Player.LookingDirection.Normal();
            animator.SetFloat(HorizontalKey, normal.x);
            animator.SetFloat(VerticalKey, normal.y);
            animator.SetBool(MovingKey, Player.HasWalked);
        }
    }
}