using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetScore : MonoBehaviour
{
    public int Skor = 0;
    public GameObject SkorYazisi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreYukselt()
    {
        Skor += 10;
        SkorYazisi.GetComponent<Text>().text = "Score: " + Skor;
    }

    public void ScoreDusur()
    {
        Skor -= 5;
        SkorYazisi.GetComponent<Text>().text = "Score: " + Skor;
    }
}
