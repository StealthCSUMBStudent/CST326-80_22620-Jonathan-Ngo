using UnityEngine;

public class LiveDemo1 : MonoBehaviour
{
    //https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Transform.RotateAround.html
    // planet script to ensure the speed of planets
    public Transform sunObject;
    public float yawDegreesPerSecond = 45f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello Unity World");
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = GetComponent<Transform>();
        //myTransform.Rotate(new Vector3(sunObject.position, 0f,yawDegreesPerSecond * Time.deltaTime));
        myTransform.RotateAround(sunObject.position, Vector3.up, yawDegreesPerSecond * Time.deltaTime);
    }
}
