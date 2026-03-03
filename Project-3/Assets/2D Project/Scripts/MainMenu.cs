using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float changeTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f);
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Destroy(gameObject);
        }
        if (Keyboard.current.rKey.isPressed)
        {
            Instantiate(gameObject);
        }
    }
}
