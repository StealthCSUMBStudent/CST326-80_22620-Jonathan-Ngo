using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody ball;
    public float ballSpeed = 10f;
    public float forceStrength = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 force = new Vector3(Random.Range(-7f, 7f), 0f, Random.Range(-7f, 7f));
        ball.linearVelocity = force * ballSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 force = new Vector3(Random.Range(-3f,3f), 0f, Random.Range(-3f,3f));
        //Rigidbody lBody = GetComponent<Rigidbody>();
        //ball.linearVelocity = force;
        //Transform myTransform = GetComponent<Transform>();
        /*
         * Vector3 force = new Vector3(0f, 0f, forceStrength);
            //Rigidbody lBody = GetComponent<Rigidbody>();
            lBody.linearVelocity = force;
         */
    }
}
