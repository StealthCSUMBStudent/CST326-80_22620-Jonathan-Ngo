using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Material-mainTextureOffset.html

public class CoinBlockAnimation : MonoBehaviour
{
    float scrollSpeed = 0.5f;
    Renderer rend;
    bool valid = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(0, offset);
    }
}
