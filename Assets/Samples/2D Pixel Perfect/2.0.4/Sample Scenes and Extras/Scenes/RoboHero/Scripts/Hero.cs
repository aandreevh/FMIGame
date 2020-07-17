using UnityEngine;

public class Hero : MonoBehaviour
{
    public enum PlayerState
    {
        Alive,
        Dead
    }

    public Animator animator;
    private AudioSource audioSource;
    private float dashCooldown;
    public bool dead;
    public Vector2 lookFacing;
    public float m_MoveSpeed;
    public PlayerState playerState = PlayerState.Alive;

    private Rigidbody2D rb;
    public Vector2 respawnPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("alive", true);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (playerState == PlayerState.Dead)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        var tryMove = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            tryMove += Vector3Int.left;
        if (Input.GetKey(KeyCode.RightArrow))
            tryMove += Vector3Int.right;
        if (Input.GetKey(KeyCode.UpArrow))
            tryMove += Vector3Int.up;
        if (Input.GetKey(KeyCode.DownArrow))
            tryMove += Vector3Int.down;

        rb.velocity = Vector3.ClampMagnitude(tryMove, 1f) * m_MoveSpeed;
        animator.SetBool("moving", tryMove.magnitude > 0);
        if (Mathf.Abs(tryMove.x) > 0)
            animator.transform.localScale = tryMove.x < 0f ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);
        if (tryMove.magnitude > 0f) lookFacing = tryMove;

        dashCooldown = Mathf.MoveTowards(dashCooldown, 0f, Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
            if (dashCooldown <= 0f && tryMove.magnitude > 0)
            {
                var hit = Physics2D.Raycast(transform.position + Vector3.up * .5f, tryMove.normalized, 3.5f,
                    1 << LayerMask.NameToLayer("Wall"));

                var distance = 3f;
                if (hit.collider != null) distance = hit.distance - .5f;

                transform.position = rb.position + Vector2.ClampMagnitude(tryMove, 1f) * distance;

                if (audioSource != null) audioSource.Play();
            }

        animator.SetBool("dash_ready", dashCooldown <= 0f);
    }

    public void LevelComplete()
    {
        Destroy(gameObject);
    }
}