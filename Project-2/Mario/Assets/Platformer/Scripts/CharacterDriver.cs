using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

public class CharacterDriver : MonoBehaviour
{
    public float groundAcceleration = 5f;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    public float apexHeight = 4.5f;
    public float apexTime = 0.5f;
    Vector2 _velocity;
    CharacterController _controller;
    Animator _animator;
    Quaternion facingRight;
    Quaternion facingLeft;
    [Header("Prefabs")]
    public LevelParser resetter;
    public Camera rayCamera;
    public Camera mainCam;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;
    public int scoreCount;
    public int coinCount;
    public AudioClip breakSound;
    AudioSource audioSource;
    float changeTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        //_controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        facingRight = Quaternion.Euler(0f, 90f, 0f);
        facingLeft = Quaternion.Euler(0f,-90f,0f) ;
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = 0f;
        if (Keyboard.current.dKey.isPressed)
        {
            direction += 1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            direction -= 1f;
        }
        bool jumpPressedThisFrame = Keyboard.current.spaceKey.wasPressedThisFrame;
        bool jumpHeld = Keyboard.current.spaceKey.isPressed;
        float gravityModifier = 1f;
            if (_controller.isGrounded) {
                if (direction != 0)
                {
                    if (Mathf.Sign(direction) != Mathf.Sign(_velocity.x))
                    {
                        _velocity.x = 0f;
                    }
                    _velocity.x += direction * groundAcceleration * Time.deltaTime;
                    _velocity.x = Mathf.Clamp(_velocity.x, -walkSpeed, walkSpeed);

                    transform.rotation = (direction > 0f) ? facingRight : facingLeft;
                }
            else
            {
                //_velocity.x *= 1f - Time.deltaTime * 2f;
                _velocity.x = Mathf.MoveTowards(_velocity.x, 0f, groundAcceleration * Time.deltaTime);
            }

            if (jumpPressedThisFrame) {
                _velocity.y = 2f * apexHeight / apexTime;

            } else
            {
                _velocity.y = -1f;
            }
        }
        else
        {
            if (!jumpHeld)
            {
                gravityModifier = 2f;
            }
        }

        float gravity = 2f * apexHeight / (apexTime * apexTime);
        _velocity.y -= gravity * gravityModifier * Time.deltaTime;//1f;

        float deltaX = _velocity.x * Time.deltaTime;
        float deltaY = _velocity.y * Time.deltaTime;

        Vector3 deltaPosition = new Vector3(deltaX, deltaY, 0f);
        CollisionFlags collisions = _controller.Move(deltaPosition);

        if ((collisions & CollisionFlags.CollidedAbove) != 0)
        {
            Debug.Log("CEILING HIT");
            Vector3 characterPosition = new Vector3(_controller.transform.position.x, _controller.transform.position.y, _controller.transform.position.z);
            Ray screenRay = new Ray(characterPosition, Vector3.up);
            if (Physics.Raycast(screenRay, out RaycastHit screenhitInfo))
            {
               // Debug.DrawLine(screenRay.origin, screenhitInfo.point, Color.blueViolet);
                if (screenhitInfo.collider.CompareTag("Brick"))
                {
                    //debugSphere.position = screenhitInfo.point;
                    Destroy(screenhitInfo.collider.gameObject);
                    audioSource.PlayOneShot(breakSound);
                    scoreCount = scoreCount + 100;
                    //000000
                    //1000
                    //10000
                    //100000
                    if (scoreCount < 1000)
                    {
                        scoreText.text = $"MARIO\n 000" + ((int)scoreCount).ToString();
                    }
                    else if (scoreCount < 10000 && scoreCount >= 1000)
                    {
                        scoreText.text = $"MARIO\n 00" + ((int)scoreCount).ToString();
                    }
                    else if (scoreCount < 1000000 && scoreCount >= 10000)
                    {
                        scoreText.text = $"MARIO\n 0" + ((int)scoreCount).ToString();
                    }
                        _velocity.y = -1f;
                    }
                if (screenhitInfo.collider.CompareTag("CoinBlock"))
                {
                    //debugSphere.position = screenhitInfo.point;
                    coinCount++;
                    if (coinCount < 10)
                    {
                        coinText.text = $"\nx0" + ((int)coinCount).ToString();
                    }
                    else
                    {
                        coinText.text = $"\nx" + ((int)coinCount).ToString();
                    }
                    if (coinCount == 25)
                    {
                        scoreCount = scoreCount + 1000;
                        coinCount = 0;
                        coinText.text = $"\nx00";
                    }
                    scoreCount = scoreCount + 100;
                    //000000
                    //1000
                    //10000
                    //100000
                    if (scoreCount < 1000)
                    {
                        scoreText.text = $"MARIO\n 000" + ((int)scoreCount).ToString();
                    }
                    else if (scoreCount < 10000 && scoreCount >= 1000)
                    {
                        scoreText.text = $"MARIO\n 00" + ((int)scoreCount).ToString();
                    }
                    else if (scoreCount < 1000000 && scoreCount >= 10000)
                    {
                        scoreText.text = $"MARIO\n 0" + ((int)scoreCount).ToString();
                    }
                }
                if (screenhitInfo.collider.CompareTag("Water"))
                {
                    //debugSphere.position = screenhitInfo.point;
                    Debug.Log("Ouch!");
                    resetter.ReloadLevel();
                    _controller.transform.position = new Vector3(11.01f, 2f, 0f);
                    mainCam.transform.position = new Vector3(16.15f, 7.5f, -11.5f);
                }
                if (screenhitInfo.collider.CompareTag("Goal"))
                {
                    //debugSphere.position = screenhitInfo.point;
                    Debug.Log("Success!");
                }
            }
            _velocity.y = -1f;

        }
        if ((collisions & CollisionFlags.Below) != 0)
        {
            
            Vector3 characterPosition = new Vector3(_controller.transform.position.x, _controller.transform.position.y, _controller.transform.position.z);
            Ray screenRay = new Ray(characterPosition, Vector3.up);
            if (Physics.Raycast(screenRay, out RaycastHit screenhitInfo))
            {
                if (screenhitInfo.collider.CompareTag("Water"))
                {
                    //debugSphere.position = screenhitInfo.point;
                    Debug.Log("Ouch!");
                    resetter.ReloadLevel();
                    _controller.transform.position = new Vector3(11.01f, 2f, 0f);
                    mainCam.transform.position = new Vector3(16.15f, 7.5f, -11.5f);
                }
            }
            _velocity.y = -1f;
        }
        if ((collisions & CollisionFlags.CollidedSides) != 0)
        {
            _velocity.x = 0f;
            Vector3 characterPosition = new Vector3(_controller.transform.position.x, _controller.transform.position.y, _controller.transform.position.z);
            Ray screenRay = new Ray(characterPosition, Vector3.up);
            if (Physics.Raycast(screenRay, out RaycastHit screenhitInfo))
            {
                if (screenhitInfo.collider.CompareTag("Goal"))
                {
                    //debugSphere.position = screenhitInfo.point;
                    Debug.Log("Success!");
                }
            }
        }

        _animator.SetFloat("Speed", Mathf.Abs(_velocity.x));
        _animator.SetBool("Grounded", _controller.isGrounded);
        //Debug.Log($"Grounded: " + _controller.isGrounded);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Water"))
        {
            //debugSphere.position = screenhitInfo.point;
            Debug.Log("Ouch!");
            resetter.ReloadLevel();
            _controller.transform.position = new Vector3(11.01f, 2f, 0f);
            mainCam.transform.position = new Vector3(16.15f, 7.5f, -11.5f);
        }
    }
}
