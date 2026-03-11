using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    private Animator anim;
    AudioSource audioSource;
    public AudioClip playerDeath;
    public AudioClip shootSound;
    float changeTime = 0;
    void Start()
    {
        // todo - get and cache animator
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
            GetComponent<Animator>().SetTrigger("Shot Trigger");
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            Debug.Log("Bang!");
            audioSource.PlayOneShot(shootSound);
            // todo - destroy the bullet after 3 seconds

            Destroy(shot, 3f);
            // todo - trigger shoot animation
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if (collision.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(collision.gameObject);
                audioSource.PlayOneShot(playerDeath);
                GetComponent<Animator>().SetTrigger("EnemyDestroyed");
                OnPlayerDied.Invoke();
                StartCoroutine(LoadCredits(2f));

            }
        }

    }

    IEnumerator LoadCredits(float delay)
    {
        yield return new WaitForSeconds(delay);
        //Destroy(gameObject, 1f);
        SceneManager.LoadScene("CreditScreen");
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
