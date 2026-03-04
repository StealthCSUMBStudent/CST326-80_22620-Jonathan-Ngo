using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderLive : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);  
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
}
