using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScreen : MonoBehaviour
{
    float changeTime = 0;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(LoadMenu(5f));
    }
    void Update()
    {
        
    }

    IEnumerator LoadMenu(float delay)
    {
        yield return new WaitForSeconds(delay);
        //Destroy(gameObject, 1f);
        SceneManager.LoadScene("SampleScene");
    }
}
