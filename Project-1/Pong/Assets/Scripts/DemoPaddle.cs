using UnityEngine;
using UnityEngine.InputSystem;

public class DemoPaddle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public Transform myTransform = GetComponent<Transform>();
    public float paddleSpeed = 1f;
    public float forceStrength = 10f;
    public Rigidbody lBody = new Rigidbody();
    public Rigidbody rBody = new Rigidbody();
    public float maxZ = 5f;
    public float ballSpeed;
        public Transform ballPos;
    public Rigidbody ball;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            Vector3 force = new Vector3(0f, 0f, forceStrength);
            //Rigidbody lBody = GetComponent<Rigidbody>();
            lBody.linearVelocity = force;
            //Transform myTransform = GetComponent<Transform>();
            //Vector3 newPosition = transform.position = new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
            //newPosition.z = Mathf.Clamp(newPosition.z, -10f, maxZ);
            //transform.position += new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
            //transform.position = newPosition;

        } else if (!Keyboard.current.wKey.isPressed){
            Vector3 force = new Vector3(0f, 0f, 0f);
            lBody.linearVelocity = force;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            Vector3 force = new Vector3(0f, 0f, -forceStrength);
            //Rigidbody lBody = GetComponent<Rigidbody>();
            lBody.linearVelocity = force;
            //Transform myTransform = GetComponent<Transform>();
            //transform.position += new Vector3(0f, 0f, -paddleSpeed) * Time.deltaTime;

        }

        if (Keyboard.current.upArrowKey.isPressed)
        {
            Vector3 force = new Vector3(0f, 0f, forceStrength);
            //Rigidbody rBody = GetComponent<Rigidbody>();
            rBody.linearVelocity = force;
            //Transform myTransform = GetComponent<Transform>();
            //transform.position += new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;

        } else if (!Keyboard.current.upArrowKey.isPressed) {
            Vector3 force = new Vector3(0f, 0f, 0f);
            rBody.linearVelocity = force;
        }

        if (Keyboard.current.downArrowKey.isPressed)
        {
            Vector3 force = new Vector3(0f, 0f, -forceStrength);
            //Rigidbody rBody = GetComponent<Rigidbody>();
            rBody.linearVelocity = force;
            //Transform myTransform = GetComponent<Transform>();
            //transform.position += new Vector3(0f, 0f, -paddleSpeed) * Time.deltaTime;

        }
        /*
        float angle = 50f;
        Vector3 up = Vector3.up;
        Quaternion testRotation = Quaternion.Euler(0f,0f,60f);
        Vector3 rotatedVector = testRotation * up;

        Quaternion otherRotation = Quaternion.Euler(-60f, 0f, 0f);
        Vector3 otherRotatedVector = otherRotation * up;

        Quaternion sotherRotation = Quaternion.Euler(angle, 0f, 0f);
        Vector3 sotherRotatedVector = sotherRotation * up;

        Debug.DrawRay(transform.position, rotatedVector * 5f, Color.red);
        */
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }
}
