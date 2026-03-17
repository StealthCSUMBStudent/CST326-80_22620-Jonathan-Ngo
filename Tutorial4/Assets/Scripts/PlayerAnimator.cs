using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    [SerializeField] private Player player;
    private Animator animator; //I had to change it to this because of some unfair bugs
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>(); //I had to change it to this because of some unfair bugs
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
