using UnityEngine;

public class Slot : MonoBehaviour
{
    public int slotNumber;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log( slotNumber + $" has collided with " + other.gameObject.name);
    }
}
