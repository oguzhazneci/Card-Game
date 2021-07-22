using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject zaman;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;
    private bool DakikaIsaretleyici = false;
    public bool stop ;
    public bool GameOver;


    public float timeRemaining;

    void Start()
    {
        stop = false;
        GameOver = false;
        timeRemaining = 0f;
    }
    void Update()
    {
        if (stop == true && GameOver == false)
        {
            Debug.Log("GAME OVER !!!!!!!");
            GameOver = true;
        }
        else if (stop == false && GameOver == false)
        {
      
                timeRemaining += Time.deltaTime;
                zaman.GetComponent<Text>().text = "Time:    " + ((int)timeRemaining) + "";
            

        }

        else
        {

        }

    }
    //call this on update
    public void Zaman()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        if(DakikaIsaretleyici==false)
            zaman.GetComponent<Text>().text = "Time:    " + (int)secondsCount + "";
        else
            zaman.GetComponent<Text>().text = "Time:    " + minuteCount + ":" + (int)secondsCount + "";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            DakikaIsaretleyici = true;
            hourCount++;
            minuteCount = 0;
        }
    }
    public void stopGame()
    {
        stop = true;
    }
}
