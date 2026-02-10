using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
//Sources Cited:
//https://vionixstudio.com/2022/06/16/unity-quaternion-and-rotation-guide/
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
    public AudioClip scoreL;
    public AudioClip scoreR;
    public AudioClip oneMoreL;
    public AudioClip oneMoreR;
    public AudioClip winnerL;
    public AudioClip winnerR;
    AudioSource audioSource;
    public Transform leftHand;
    public Transform rightHand;
    public int leftHandPower;
    public int rightHandPower;
    Quaternion rotationLpost = Quaternion.Euler(6.9f, 0f, 0f);
    Quaternion rotationLpre = Quaternion.Euler(6.76f, 15.1f, 1.8f);
    Quaternion rotationRpost = Quaternion.Euler(6.9f, 0f, 0f);
    Quaternion rotationRpre = Quaternion.Euler(6.76f, -15.1f, 1.8f);
    Color red = new Color(255f,0f,0f);

    //ScorezoneForLeftToScore
    //ScorezoneForRightToScore

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftHandPower = 0;
        rightHandPower = 0;
        leftScoreNum = 0;
        rightScoreNum = 0;
        leftText.color = Color.white;
        rightText.color = Color.white;
        leftHand.position = new Vector3(-4.12f,26.9f,-20.6f);
        rightHand.position = new Vector3(4.12f, 26.9f, -20.6f);
        leftHand.rotation = rotationLpre;
        rightHand.rotation = rotationRpre;
    }
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            if (leftHandPower > 0)
            {
                leftHand.position = new Vector3(12.7f, 23.8f, 3.9f);
                leftHand.rotation = rotationLpost;
                leftHandPower--;
                Debug.Log($" Left Hand Power: " + leftHandPower);
            }

        }

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            if (rightHandPower > 0)
            {
                rightHand.position = new Vector3(-12.7f, 23.8f, 3.9f);
                rightHand.rotation = rotationRpost;
                rightHandPower--;
                Debug.Log($" Right Hand Power: " + rightHandPower);
            }
        }
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
                leftHandPower = 0;
                rightHandPower = 0;
                leftText.color = Color.white;
                rightText.color = Color.white;
                Debug.Log($" Game Over, Right Paddle Wins");
                audioSource.PlayOneShot(winnerR);
                leftHand.position = new Vector3(-4.12f, 26.9f, -20.6f);
                rightHand.position = new Vector3(4.12f, 26.9f, -20.6f);
                leftHand.rotation = rotationLpre;
                rightHand.rotation = rotationRpre;
                ballPos.position = new Vector3(0f, 0f, 0f);
                Vector3 force = new Vector3(Random.Range(-3f, -2f), 0f, Random.Range(-3f, -2f));
                ball.linearVelocity = force * ballSpeed;
                SetCountTextR();
                SetCountTextL();
            } else
            {
                rightScoreNum++;
                Debug.Log($" Player 2 has scored. Their score is: " + rightScoreNum);
                if (rightScoreNum <= 9)
                {
                    audioSource.PlayOneShot(scoreR);
                }
                if (rightScoreNum > 9)
                {
                    audioSource.PlayOneShot(oneMoreR);
                    rightText.color = Color.green;
                }
                if (rightScoreNum >= 3 && rightScoreNum <= 6)
                {
                    rightText.color = Color.red;
                }
                if (rightScoreNum >= 7 && rightScoreNum <= 8)
                {
                    rightText.color = Color.yellow;
                }
                if (rightScoreNum == 3 || rightScoreNum == 6 || rightScoreNum == 9)
                {
                    leftHandPower++;
                    Debug.Log($" Left Hand Power: " + leftHandPower);
                }
                rightHand.position = new Vector3(4.12f, 26.9f, -20.6f);
                rightHand.rotation = rotationRpre;
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
                leftText.color = Color.white;
                rightText.color = Color.white;
                Debug.Log($" Game Over, Left Paddle Wins");
                audioSource.PlayOneShot(winnerL);
                leftHand.position = new Vector3(-4.12f, 26.9f, -20.6f);
                rightHand.position = new Vector3(4.12f, 26.9f, -20.6f);
                leftHand.rotation = rotationLpre;
                rightHand.rotation = rotationRpre;
                ballPos.position = new Vector3(0f, 0f, 0f);
                Vector3 force = new Vector3(Random.Range(3f, 5f), 0f, Random.Range(3f, 5f));
                ball.linearVelocity = force * ballSpeed;
                SetCountTextL();
                SetCountTextR();
            }else
            {
                leftScoreNum++;
                Debug.Log($" Player 1 has scored. Their score is: " + leftScoreNum);
                if (leftScoreNum <= 9)
                {
                    audioSource.PlayOneShot(scoreL);
                }
                if (leftScoreNum > 9)
                {
                    audioSource.PlayOneShot(oneMoreL);
                    leftText.color = Color.green;
                }
                if (leftScoreNum >= 3 && leftScoreNum <= 6)
                {
                    leftText.color = Color.red;
                }
                if (leftScoreNum >= 7 && leftScoreNum <= 8)
                {
                    leftText.color = Color.yellow;
                }
                if (leftScoreNum == 3 || leftScoreNum == 6 || leftScoreNum == 9)
                {
                    rightHandPower++;
                    Debug.Log($" Right Hand Power: " + rightHandPower);
                }
                leftHand.position = new Vector3(-4.12f, 26.9f, -20.6f);
                leftHand.rotation = rotationLpre;
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
