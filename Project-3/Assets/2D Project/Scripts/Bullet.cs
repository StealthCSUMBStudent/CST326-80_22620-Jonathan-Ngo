using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float speed = 5;

    void Start()
    {
        //Debug.Log("Wwweeeeee");
        if (gameObject.CompareTag("EnemyBullet"))
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;
        }
        if (gameObject.CompareTag("PlayerBullet"))
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * speed;
        }
    }
}
