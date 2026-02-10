using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class JoystickAsethetic : MonoBehaviour
{
    public Transform JoystickL;
    public Transform JoystickR;
    float _rotationSpeed = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Keyboard.current.wKey.isPressed)
        {
            JoystickL.Rotate(_rotationSpeed * Time.deltaTime,0f,0f);

        }

        if (Keyboard.current.sKey.isPressed)
        {
            JoystickL.Rotate(-(_rotationSpeed * Time.deltaTime), 0f, 0f);

        }

        if (Keyboard.current.upArrowKey.isPressed)
        {
            JoystickR.Rotate(_rotationSpeed * Time.deltaTime, 0f, 0f);

        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            JoystickR.Rotate(-(_rotationSpeed * Time.deltaTime), 0f, 0f);

        }
    }
}
