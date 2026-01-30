using UnityEngine;

public class TriggerScore : MonoBehaviour
{
    public int leftScoreNum;
    public int rightScoreNum;
    public Collider leftCollider;
    public Collider rightCollider;
    public Transform ballPos;
    public Rigidbody ball;
    public float ballSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftScoreNum = 0;
        rightScoreNum = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (leftScoreNum == 10)
        {
            leftScoreNum = 0;
            Debug.Log($" Game Over, Left Paddle Wins");
            ballPos.position = new Vector3(0f, 0f, 0f);
            Vector3 force = new Vector3(Random.Range(2f, 3f), 0f, Random.Range(2f, 3f));
            ball.linearVelocity = force * ballSpeed;
        } else
        {
            leftScoreNum++;
            Debug.Log($" Player 1 has scored. Score: " + leftScoreNum);
            ballPos.position = new Vector3(0f, 0f, 0f);
            Vector3 force = new Vector3(Random.Range(2f, 3f), 0f, Random.Range(2f, 3f));
            ball.linearVelocity = force * ballSpeed;
        }

    }
}
