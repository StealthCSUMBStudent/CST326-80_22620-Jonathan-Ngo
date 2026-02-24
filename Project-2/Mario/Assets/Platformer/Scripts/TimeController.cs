using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TimeController : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    bool timeUpStatus = false;
    int timeLeft = 100;
    float changeTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = $"TIME:\n" + ((int)timeLeft).ToString();
        if (Time.time > changeTime + 1 && timeLeft != 0)
        {
            timeLeft--;
            changeTime = Time.time;
        }
        if (timeLeft == 0 && !timeUpStatus)
        {
            Debug.Log("TIMES UP!");
            timeUpStatus = true;
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
