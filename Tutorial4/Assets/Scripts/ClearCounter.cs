using UnityEngine;
using UnityEngine.InputSystem;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSo;
    //[SerializeField] private Transform counterTopPoint;
    //[SerializeField] private ClearCounter secondClearCounter;
    //[SerializeField] private bool testing;

    //private KitchenObject kitchenObject;

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
    public override void Interact(Player player)
    {
        //Debug.Log("Interact!");
        //Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
        if (!HasKitchenObject())
        {
            //There is no KitchenObject here
            if (player.HasKitchenObject())
            {   
                //player has somethjing
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else
            {
                //player has nothing
            }
        } else
        {
            //There is Kitchen Object
            if (player.HasKitchenObject())
            {
                //player has something

            }
            else
            {
                //player has nothing
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
