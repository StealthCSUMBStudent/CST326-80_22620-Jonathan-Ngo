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

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Ouch!");

        // todo - destroy the bullet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            if (gameObject.CompareTag("LowerEnemy"))
            {
                Debug.Log("Weak Enemy Defeated");
                OnEnemyDied.Invoke(10);
            }
            if (gameObject.CompareTag("MidEnemy"))
            {
                Debug.Log("Middle Enemy Defeated");
                OnEnemyDied.Invoke(20);
            }
            if (gameObject.CompareTag("HighEnemy"))
            {
                Debug.Log("Higher Enemy Defeated");
                OnEnemyDied.Invoke(30);
            }
            if (gameObject.CompareTag("MotherShip"))
            {
                Debug.Log("Mothership Defeated");
                OnEnemyDied.Invoke(250);
            }
        }
        // todo - trigger death animation
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
