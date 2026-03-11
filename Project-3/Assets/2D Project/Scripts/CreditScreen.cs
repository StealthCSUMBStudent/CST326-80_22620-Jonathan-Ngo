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
    public void LoadGame()
    {
        StartCoroutine(_LoadGame());
        //Debug.Log("hello anxiety my old friend");

        IEnumerator _LoadGame()
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync("Schmup");
            while (!loadOperation.isDone) yield return null;

            //SceneManager.LoadScene("Schmup");

            GameObject playerObj = GameObject.Find("Player");
            Debug.Log(playerObj.name);
        }
    }

    public void LoadCredits()
    {
        StartCoroutine(_LoadCredits());
        //Debug.Log("hello anxiety my old friend");

        IEnumerator _LoadCredits()
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync("CreditScreen");
            while (!loadOperation.isDone) yield return null;

            //SceneManager.LoadScene("CreditScene");
        }
    }
    IEnumerator LoadMenu(float delay)
    {
        yield return new WaitForSeconds(delay);
        //Destroy(gameObject, 1f);
        SceneManager.LoadScene("SampleScene");
    }
}
