using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMover : MonoBehaviour
{
    public Transform camMover;
    public Rigidbody camMoverRigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camMover.position = new Vector3(16.15f,7.5f,1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            Vector3 force = new Vector3(4.5f, 0f, 0f);
            camMoverRigid.linearVelocity = force;
        }
        else if (!Keyboard.current.rightArrowKey.isPressed)
        {
            Vector3 force = new Vector3(0f, 0f, 0f);
            camMoverRigid.linearVelocity = force;
        }
        
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            Vector3 force = new Vector3(-4.5f, 0f, 0f);
            camMoverRigid.linearVelocity = force;
        }
        
    }
}
