using UnityEngine;
using UnityEngine.Rendering;

public class SpaceBackdrop : MonoBehaviour
{
    float scrollSpeed = 0.5f;
    Renderer rend;
    bool valid = false;
    AudioSource audioSource;
    public AudioClip music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
        audioSource.PlayOneShot(music);
    }
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset,0 );
    }
}
