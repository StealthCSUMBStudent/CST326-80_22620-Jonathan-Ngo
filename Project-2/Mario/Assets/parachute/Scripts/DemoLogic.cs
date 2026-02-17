using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class DemoLogic : MonoBehaviour
{
    public Rigidbody payload;
    public float parachuteDeployHeight = 3f;
    public Transform parachute;
    float _startingDrag;
    public Camera rayCamera;
    public Transform debugSphere;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startingDrag = payload.linearDamping;

        //StartCoroutine(LearnAboutCouratine());
        //StartCoroutine(AnimateParachuteScale(Vector3.zero,Vector3.one,2f));
    }
    /*
    IEnumerator LearnAboutCouratine()
    {
        Debug.Log("Starting couratine #0");
        yield return new WaitForSeconds(1f);
        Debug.Log("Waited #1");
        yield return new WaitForSeconds(1f);
        Debug.Log("Waited #2");
    }
    */
    // Update is called once per frame
    void Update()
    {
        // create ray
        Ray proximityRay = new Ray(payload.position + Vector3.up * 0.01f, Vector3.down);

        //ray hit
        bool intersects = Physics.Raycast(proximityRay, out RaycastHit hitInfo);
        //visual red, ow blue
        if (intersects && hitInfo.distance <1f)
        {
            //parachute.gameObject.SetActive(true);
            StartCoroutine(AnimateParachuteScale(Vector3.zero, Vector3.one, 0.5f));
            payload.linearDamping = 7f;
            Debug.DrawRay(proximityRay.origin,proximityRay.direction,Color.red);
        }
        else
        {
            payload.linearDamping = _startingDrag; ;
            Debug.DrawRay(proximityRay.origin, proximityRay.direction, Color.blue);
        }

        Vector3 mousePosition = Mouse.current.position.value;
        Ray screenRay = rayCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(screenRay,out RaycastHit screenhitInfo))
        {
            Debug.DrawLine(screenRay.origin,screenhitInfo.point,Color.blueViolet);
            if (Mouse.current.leftButton.wasPressedThisFrame){
                debugSphere.position = screenhitInfo.point;
            }
        }
    }

    IEnumerator AnimateParachuteScale(Vector3 startScale, Vector3 endScale, float duration)
    {
        //start clock
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float percentComplete = timeElapsed / duration;
            float easedPercent = easeOutQuart(percentComplete);
            parachute.localScale = startScale + (endScale + startScale) * percentComplete;
            yield return null;
        }
        //loop
        //- each frame, adjust the scale by percentage of time elapsed toward the duration
        parachute.localScale = endScale;
        //clamp the final scale to be the endScale
    
    }

    float easeOutElastic (float x)
    {
        float c4 = (2f * Mathf.PI) / 3f;

        return x == 0f ? 0 : x == 1f ? 1f : Mathf.Pow(2f,10f*x) * Mathf.Sin((x * 10f - 0.75f) * c4) +1f;
    }

    float easeOutQuart(float x)
    {
        return 1f - Mathf.Pow(1f - x, 4f);
    }
}
