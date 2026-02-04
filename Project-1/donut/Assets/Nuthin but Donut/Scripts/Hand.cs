using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform ball;
    Rigidbody rb;

    void Start()
    {
        rb = ball.gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        //rb.useGravity = false;
    }

    public void Release()
    {
        rb.isKinematic = false;
        //rb.useGravity = true;
    }

    public void Reset()
    {
        ball.transform.position = gameObject.transform.position;
        rb.isKinematic = true;
        //rb.useGravity = false;
        //rb.linearVelocity = Vector3.zero;
    }
}
