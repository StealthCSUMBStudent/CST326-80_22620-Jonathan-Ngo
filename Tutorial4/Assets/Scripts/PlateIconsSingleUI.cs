using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
public class PlateIconsSingleUI : MonoBehaviour
{

    [SerializeField] private Image image;
    public void SetKitchenObjectSO(KitchenObjectSO kitchenObjectSO)
    {
        image.sprite = kitchenObjectSO.sprite;
    }
}
