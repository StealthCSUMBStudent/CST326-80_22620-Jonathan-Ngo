using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int moveCount = 0;
    AudioSource audioSource;

    float changeTime = 0;
    public float enemySpeed = 0.5f;
    public int enemyCount = 3;
    void Update()
    {
        if (Time.time > changeTime + 0.5)
        {
            changeTime = Time.time;
            MoveAround();
        }
        
    }
    public void MoveAround()
    {
        if (moveCount < 4)
        {
            //right
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + enemySpeed, gameObject.transform.position.y);
            Debug.Log("Count of moveCount: " + moveCount);
        }
        else if (moveCount < 8)
        {
            //center
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - enemySpeed, gameObject.transform.position.y);
            Debug.Log("Count of moveCount: " + moveCount);
        }
        else if (moveCount >= 8 && moveCount < 12)
        {
            //left
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - enemySpeed, gameObject.transform.position.y);
            Debug.Log("Count of moveCount: " + moveCount);
        }
        else if (moveCount >= 12 && moveCount < 16)
        {
            //center
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + enemySpeed, gameObject.transform.position.y);
            Debug.Log("Count of moveCount: " + moveCount);
        }
        moveCount++;
        if (moveCount >= 16)
        {
            moveCount = 0; //
            Debug.Log("Reset moveCount to: " + moveCount);
        }
    }
}
