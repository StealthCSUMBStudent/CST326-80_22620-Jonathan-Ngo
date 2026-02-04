using UnityEngine;

public class LookAt : MonoBehaviour {
    public Transform target;

    void Update()
    {
        transform.LookAt(target.position);    
    }
    // todo - make an object look at another object
}
