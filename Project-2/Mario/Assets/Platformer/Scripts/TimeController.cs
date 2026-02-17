using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TimeController : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    int timeLeft = 500;
    float changeTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = $"TIME:\n" + ((int)timeLeft).ToString();
        if (Time.time > changeTime + 1)
        {
            timeLeft--;
            changeTime = Time.time;
        }
    }
    IEnumerator LearnAboutCouratine()
    {
        while (timeLeft > 0)
        {
            timeLeft--;
            yield return new WaitForSeconds(1f);
        }
    }
}
