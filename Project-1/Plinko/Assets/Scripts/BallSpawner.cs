using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    //https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Random.Range.html
    //https://discussions.unity.com/t/how-to-add-delay-before-button-can-be-pressed-code-is-executed-again/921250
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float changeTime = 0;
    void newSpawn()
    {
        Transform myTransform = GetComponent<Transform>();
        Vector3 randomPos = new Vector3(Random.Range(0f, 3f), myTransform.position.y, 0);
        Instantiate(ballPrefab, randomPos, Quaternion.identity);
        //Instantiate(ballPrefab);
    }
    void Start()
    {
        //Instantiate(ballPrefab);
        newSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed && Time.time > changeTime + 1)
        {

            newSpawn();
            changeTime = Time.time;
            //Transform myTransform = GetComponent<Transform>();
            //Vector3 randomPos = new Vector3(Random.Range(0f, 3f), myTransform.position.y,0);
            //Instantiate(ballPrefab, randomPos, Quaternion.identity);
            //Instantiate(ballPrefab);
        }
    }
}
