using UnityEngine;
using UnityEngine.InputSystem;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{

    [SerializeField] private KitchenObjectSO kitchenObjectSo;
    [SerializeField] private Transform counterTopPoint;
    //[SerializeField] private ClearCounter secondClearCounter;
    //[SerializeField] private bool testing;

    private KitchenObject kitchenObject;

    /*
    private void Update()
    {
        if (testing && Keyboard.current.tKey.wasPressedThisFrame) //Input.GetKeyDown(KeyCode.T)) 
            //Keyboard.current.tKey.wasPressedThisFrame;
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetKitchenObjectParent(secondClearCounter);
                //Debug.Log(kitchenObject.GetClearCounter());
            }
        }
    }
    */
    public void Interact(Player player)
    {
        //Debug.Log("Interact!");
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
            /*
            kitchenObjectTransform.localPosition = Vector3.zero;
            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.SetClearCounter(this);
            */

        } else
        {
            //kitchenObject.SetClearCounter(player);
            //Debug.Log(kitchenObject.GetClearCounter());
            kitchenObject.SetKitchenObjectParent(player);
        }

        //Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() { return kitchenObject; }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
