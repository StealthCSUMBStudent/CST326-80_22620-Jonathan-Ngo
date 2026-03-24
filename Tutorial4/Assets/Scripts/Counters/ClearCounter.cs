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
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //Player is holding a plate
                    //PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    //player not carrying plate. but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        // counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }

                    }
                }
            }
            else
            {
                //player has nothing
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
