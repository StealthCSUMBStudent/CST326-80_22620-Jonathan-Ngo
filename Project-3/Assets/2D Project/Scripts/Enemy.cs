using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDiedFunc(float points);
    public static event EnemyDiedFunc OnEnemyDied;
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    public Transform EnemyMove;
    public AudioClip tic;
    public AudioClip tac;
    public int moveCount = 0;
    AudioSource audioSource;
    float changeTime = 0;
    float ShootTime = 0;
    public float enemySpeed = 0.5f;
    public int enemyCount = 3;
    public EnemyMovement blast;
    private Animator anim;
    private SpriteRenderer sr;
    public static int enemyLeft = 3;
    public AudioClip enemyDeath;
    public AudioClip enemyShoot;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Ouch!");

        // todo - destroy the bullet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            // todo - trigger death animation
            audioSource.PlayOneShot(enemyDeath);
            anim.SetTrigger("EnemyDestroyed");
            Destroy(gameObject,1f);
            if (gameObject.CompareTag("LowerEnemy"))
            {
                Debug.Log("Weak Enemy Defeated");
                OnEnemyDied.Invoke(10);
                EnemyMovement.modifierTime -= 0.15f;
                Debug.Log("NEW TIME SPEED: " + EnemyMovement.modifierTime);
                enemyLeft--;
            }
            if (gameObject.CompareTag("MidEnemy"))
            {
                Debug.Log("Middle Enemy Defeated");
                OnEnemyDied.Invoke(20);
                EnemyMovement.modifierTime -= 0.15f;
                Debug.Log("NEW TIME SPEED: " + EnemyMovement.modifierTime);
                enemyLeft--;
            }
            if (gameObject.CompareTag("HighEnemy"))
            {
                Debug.Log("Higher Enemy Defeated");
                OnEnemyDied.Invoke(30);
                EnemyMovement.modifierTime -= 0.15f;
                Debug.Log("NEW TIME SPEED: " + EnemyMovement.modifierTime);
                enemyLeft--;
            }
            if (gameObject.CompareTag("MotherShip"))
            {
                Debug.Log("Mothership Defeated");
                OnEnemyDied.Invoke(250);
            }
        }
        Debug.Log("Enemies Left" + enemyLeft);
        if (enemyLeft == 0)
        {
            StartCoroutine(LoadCredits(0.5f));
        }
    }
    private IEnumerator HandleDeathAnimation()
    {
        anim.SetTrigger("EnemyDestroyed");

        yield return new WaitForSeconds(1.0f); 

        Destroy(gameObject);
    }
    public void Update()
    {
        if (gameObject.CompareTag("HighEnemy"))
        {
            if (Time.time > ShootTime + 5)
            {
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                audioSource.PlayOneShot(enemyShoot);
                Destroy(shot, 3f);
                ShootTime = Time.time;
                GetComponent<Animator>().SetTrigger("Shot TriggerE");
            }
        }
    }
    public void PlayTickSound()
    {
        //Debug.Log("Tic");
       

    }
    IEnumerator LoadCredits(float delay)
    {
        yield return new WaitForSeconds(delay);
        //Destroy(gameObject, 1f);
        SceneManager.LoadScene("CreditScreen");
    }
    public void PlayTacSound()
    {
        //Debug.Log("Tac");
        GetComponent<AudioSource>().PlayOneShot(tac);
    }


    
}
