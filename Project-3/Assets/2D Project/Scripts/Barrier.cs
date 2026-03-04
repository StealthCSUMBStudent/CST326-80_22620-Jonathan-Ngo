using UnityEngine;

public class Barrier : MonoBehaviour
{
    public delegate void BarrierDestroyedFunc();
    public static event BarrierDestroyedFunc OnBarrierGone;


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Ouch!");

        // todo - destroy the bullet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            OnBarrierGone.Invoke();
        }
        // todo - trigger death animation
    }

    public void Update()
    {
    }

}
