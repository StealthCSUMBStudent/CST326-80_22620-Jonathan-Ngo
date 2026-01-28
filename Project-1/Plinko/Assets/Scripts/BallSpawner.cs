using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(ballPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            Transform myTransform = GetComponent<Transform>();
            Instantiate(ballPrefab, myTransform.position, Quaternion.identity);
            //Instantiate(ballPrefab);
        }
    }
}
