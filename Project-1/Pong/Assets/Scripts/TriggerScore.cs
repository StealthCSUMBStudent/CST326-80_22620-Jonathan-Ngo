using UnityEngine;
using TMPro;
public class TriggerScore : MonoBehaviour
{
    public int leftScoreNum;
    public int rightScoreNum;
    public Collider leftCollider;
    public Collider rightCollider;
    public Transform ballPos;
    public Rigidbody ball;
    public float ballSpeed = 10f;
    public BallScript transfer;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
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
        /*
         * I know this may look weird, but the original intent was that leftCollider was to score for player 2 whose on the right and vice versa. Since
         * The ball hits the left side therefore giving right side the point and vice versa. Admittingly this confused me for a bit.
        */
        if (gameObject == leftCollider.gameObject) //check if it was the left net was hit
        {
            if (rightScoreNum > 9)
            {
                leftScoreNum = 0; //ensure score goes back to 0 since a "scoring" still occurs, if this was set to 0, it would become 1!
                rightScoreNum = 0;
                Debug.Log($" Game Over, Right Paddle Wins");
                ballPos.position = new Vector3(0f, 0f, 0f);
                Vector3 force = new Vector3(Random.Range(-3f, -2f), 0f, Random.Range(-3f, -2f));
                ball.linearVelocity = force * ballSpeed;
                SetCountTextR();
                SetCountTextL();
            } else
            {
                rightScoreNum++;
                Debug.Log($" Player 2 has scored. Their score is: " + rightScoreNum);
                ballPos.position = new Vector3(0f, 0f, 0f);
                Vector3 force = new Vector3(Random.Range(-5f, -3f), 0f, Random.Range(-5f, -3f));
                ball.linearVelocity = force * ballSpeed;
                transfer.resetSpeed();
                SetCountTextR();
            }
        }
        if (gameObject == rightCollider.gameObject) // check if the right net was hit
        {
            if (leftScoreNum > 9)
            {
                rightScoreNum = 0; //ensure score goes back to 0 since a "scoring" still occurs, if this was set to 0, it would become 1!
                leftScoreNum = 0;
                Debug.Log($" Game Over, Left Paddle Wins");
                ballPos.position = new Vector3(0f, 0f, 0f);
                Vector3 force = new Vector3(Random.Range(3f, 5f), 0f, Random.Range(3f, 5f));
                ball.linearVelocity = force * ballSpeed;
                SetCountTextL();
                SetCountTextR();
            }else
            {
                leftScoreNum++;
                Debug.Log($" Player 1 has scored. Their score is: " + leftScoreNum);
                ballPos.position = new Vector3(0f, 0f, 0f);
                Vector3 force = new Vector3(Random.Range(3f, 5f), 0f, Random.Range(3f, 5f));
                ball.linearVelocity = force * ballSpeed;
                transfer.resetSpeed();
                SetCountTextL();
            }
        }

    }

    void SetCountTextL()
    {
        leftText.text = "Left Paddle: " + leftScoreNum.ToString();
    }
    void SetCountTextR()
    {
        rightText.text = "Right Paddle: " + rightScoreNum.ToString();
    }
}
