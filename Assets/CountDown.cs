using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour
{
    public float timeLeft;
    public bool isFinished = false;
    public bool startTimer = false;

    public void Begin() {
        timeLeft = 9f;
        isFinished = false;
        startTimer = true;
    }

    public void Stop()
    {
        startTimer = false;
        timeLeft = 9f;
    }

    void Update()
    {
        if (startTimer) {
        
        timeLeft -= Time.deltaTime;
        //Debug.Log("timeleft" + timeLeft);
        if (timeLeft < 0)
        {
            isFinished = true;
        }
        else {
            isFinished = false;
        }
        }
    }
}