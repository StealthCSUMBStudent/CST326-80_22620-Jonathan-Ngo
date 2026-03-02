using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDiedFunc(float points);
    public static event EnemyDiedFunc OnEnemyDied;

    public AudioClip tic;
    public AudioClip tac;
    AudioSource audioSource;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");

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
        }
        // todo - trigger death animation
    }

    public void PlayTickSound()
    {
        //Debug.Log("Tic");
       GetComponent<AudioSource>().PlayOneShot(tic);

    }

    public void PlayTacSound()
    {
        //Debug.Log("Tac");
        GetComponent<AudioSource>().PlayOneShot(tac);
    }
}
