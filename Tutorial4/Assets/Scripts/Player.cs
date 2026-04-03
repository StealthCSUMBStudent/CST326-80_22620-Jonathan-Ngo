using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;
using Mono.Cecil;
public class Player : MonoBehaviour, IKitchenObjectParent
{
    private static Player instance;
    public static Player Instance // dont use private for this as a whole. only set
    {
        get; private set;
        
    }
    public event EventHandler OnPickedSomething;
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;
    [SerializeField] private Transform kitchenObjectHoldPoint;
    private bool isWalking;
    private Vector3 lastInteractDir;
    private BaseCounter selectedCounter;
    private KitchenObject kitchenObject;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than 1 Player instance");
        }
        Instance = this;
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnInteractAlternateAction += GameInput_OnInteractAlternateAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }

    private void GameInput_OnInteractAlternateAction(object sender, System.EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.InteractAlternate(this);
        }
    }
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y); //writing good plain code
        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position ,lastInteractDir,out RaycastHit hit, interactDistance, countersLayerMask))
        {
            //Debug.Log(hit.transform);
            if (hit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                //Debug.Log("Interacted");
                //clearCounter.Interact();
                if(baseCounter != selectedCounter)
                {
                    SetSelectedCounter(baseCounter);// = clearCounter;
                }
            } else
            {
                SetSelectedCounter(null); //null;

            }
        } else
        {
            SetSelectedCounter(null);
        }
        //Debug.Log(selectedCounter);

    }
    private void HandleMovement()
    {
        //Input.GetKey -stays true as long as key is held down. Movement purpose
        //GetKeyDown 1 frame. Meant for jumping -> (Keyboard.current.spaceKey.wasPressedThisFrame)
        /*
        Vector2 inputVector = new Vector2(0, 0);
        if (Keyboard.current.wKey.isPressed) { //Input.GetKey(KeyCode.W)){
            //Debug.Log("Pressing!");
            inputVector.y = +1;
        }
        if (Keyboard.current.sKey.isPressed)
        { //Input.GetKey(KeyCode.S)){
            //Debug.Log("Pressing!");
            inputVector.y = -1;
        }
        if (Keyboard.current.aKey.isPressed)
        { //Input.GetKey(KeyCode.A)){
            //Debug.Log("Pressing!");
            inputVector.x = -1;
        }
        if (Keyboard.current.dKey.isPressed)
        { //Input.GetKey(KeyCode.D)){
            //Debug.Log("Pressing!");
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;
        */
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y); //writing good plain code
        //transform.position += moveDir * moveSpeed * Time.deltaTime;
        float moveDistance = moveSpeed * Time.deltaTime;
        float playerSize = .4f;
        float playerHeight = 2f;
        bool canMove = moveDir.x != 0 &&  !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, moveDir, moveDistance);

        if (!canMove)
        {
            //cannot move towards moveDir
            //Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, moveDirX, moveDistance);
            if (canMove)
            {
                //only on x
                moveDir = moveDirX;

            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, moveDirZ, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else
                {

                }
            }
        }
        if (canMove)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

        isWalking = moveDir != Vector3.zero;
        //Lookat or EulerAngles or forward. up and right for 2d
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

        //Debug.Log(inputVector)
    }
    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = selectedCounter
        });
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;

        if (kitchenObject != null)
        {
            OnPickedSomething?.Invoke(this, EventArgs.Empty);
        }
    }

    public KitchenObject GetKitchenObject() 
    { 
        return kitchenObject; 
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
