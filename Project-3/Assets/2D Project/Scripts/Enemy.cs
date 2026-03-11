using System.Collections;
using UnityEngine;

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
    public float enemySpeed = 0.5f;
    public int enemyCount = 3;
    public EnemyMovement blast;
    private Animator anim;
    private SpriteRenderer sr;
    public int enemyLeft = 3;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Ouch!");

        // todo - destroy the bullet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            // todo - trigger death animation
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
            if (Time.time > changeTime + 5)
            {
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                Destroy(shot, 3f);
                changeTime = Time.time;
            }
        }
    }
    public void PlayTickSound()
    {
        //Debug.Log("Tic");
       

    }

    public void PlayTacSound()
    {
        //Debug.Log("Tac");
        GetComponent<AudioSource>().PlayOneShot(tac);
    }


    
}
