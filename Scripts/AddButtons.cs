using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButtons : MonoBehaviour
{
    public GameObject prefab;
    public GameObject SideA;
    public GameObject SideB;
    public GameObject ilk;

    public int ButtonSayisi;
    public int Baslangic;
    public int Bitis;
    public int ArtisMiktari;
    public int DogruYanit;
    public int[] Sayilar;
    public int[] SirasizSayilar;
    bool tiklandimi = false;

    
    // Start is called before the first frame update
    void Start()
    {
        Sayilar = new int[ButtonSayisi];
        AddingButtons(SideA);
        AddingRandomlyButtons(SideB);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Control(GameObject tiklanan)
    {
        if(tiklandimi==false)
        {
            ilk = tiklanan;
            tiklandimi = true;
        }
        else
        {
            if ((ilk.transform.GetChild(0).gameObject.GetComponent<Text>().text) == (tiklanan.transform.GetChild(0).gameObject.GetComponent<Text>().text))
            {
                tiklanan.SetActive(false);
                ilk.SetActive(false);
                tiklandimi = false;
                DogruYanit++;
                Debug.Log("True!");
                gameObject.GetComponent<GetScore>().ScoreYukselt();
            }
            else
            {
                tiklanan = null;
                tiklandimi = false;
                Debug.Log("False!");
                gameObject.GetComponent<GetScore>().ScoreDusur();
            }
            ilk = null;
            if(DogruYanit==ButtonSayisi)
            {
                Debug.Log("Game Over!");
                gameObject.GetComponent<Timer>().stop = true;
               // gameObject.GetComponent<Timer>().stopGame();
            }
        }
    }
    public void AddingButtons(GameObject parentObj)
    {
        for (int i = 0; i < ButtonSayisi; i++)
        {
            var obj = Instantiate(prefab);
            obj.transform.SetParent(parentObj.GetComponent<RectTransform>(), false);
            obj.GetComponent<RectTransform>().anchoredPosition = parentObj.GetComponent<RectTransform>().anchoredPosition;
            obj.transform.GetChild(0).gameObject.GetComponent<Text>().text = (i + 1)+"";
            Sayilar[i] = int.Parse(obj.GetComponentInChildren<Text>().text); 
            obj.GetComponent<Button>().onClick.AddListener(() => Control(obj));
        }
    }
    public void AddingRandomlyButtons(GameObject parentObj)
    {
        RandomizeNumbers(Sayilar);
        for (int i = 0; i < ButtonSayisi; i++)
        {
            var obj = Instantiate(prefab);
            obj.transform.SetParent(parentObj.GetComponent<RectTransform>(), false);
            obj.GetComponent<RectTransform>().anchoredPosition = parentObj.GetComponent<RectTransform>().anchoredPosition;
            obj.transform.GetChild(0).gameObject.GetComponent<Text>().text = (SirasizSayilar[i]) + "";
            obj.GetComponent<Button>().onClick.AddListener(() => Control(obj));
        }
    }
    public void RandomizeNumbers(int[] Sayilar)
    {
        SirasizSayilar = Sayilar;
        Random rand = new Random();

        for (int t = 0; t < SirasizSayilar.Length; t++)
        {
            var tmp = SirasizSayilar[t];
            int r = Random.Range(t, SirasizSayilar.Length);
            SirasizSayilar[t] = SirasizSayilar[r];
            SirasizSayilar[r] = tmp;
        }
    }
    
}
