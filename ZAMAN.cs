using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ZAMAN : MonoBehaviour
{
    public float dakika, saniye;
    public Text SureText;
    
    void Start()
    {
        dakika = 0;
        saniye = 59;
    }

    // Update is called once per frame
    void Update()
    {
        saniye -=Time.deltaTime;
        SureText.text = "" + dakika + ":" + (int)saniye;

        if(saniye<= 0 )
        {
            dakika--;
            saniye = 59;
        }
        if (dakika < 0)
        {
            Time.timeScale = 0;

            SceneManager.LoadScene("OyunBitti");
        }
    }
}
