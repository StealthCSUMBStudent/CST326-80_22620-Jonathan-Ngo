using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject menu;
    float changeTime;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(menu.gameObject, 3f);
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Destroy(menu.gameObject);
        }
        
    }
}
