using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public delegate void PlayerDiedFunc();
    public static event PlayerDiedFunc OnPlayerDied;
    public Transform shootOffsetTransform;
    private Rigidbody2D rb;
    private float movementX;
    private float movementY;
    public float moveSpeed = 5f;
    void Start()
    {
        // todo - get and cache animator
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX, movementY);
        rb.linearVelocity = movement * moveSpeed;
    }
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            Debug.Log("Bang!");

            // todo - destroy the bullet after 3 seconds

            Destroy(shot, 3f);
            // todo - trigger shoot animation
            GetComponent<Animator>().SetTrigger("Shot Trigger");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
        void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
