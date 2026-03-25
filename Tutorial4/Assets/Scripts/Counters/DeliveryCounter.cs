using UnityEngine;

public class DeliveryCounter : BaseCounter
{

    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                // Only access if its a plate
                player.GetKitchenObject().DestroySelf();
            }
        }
    }

}
