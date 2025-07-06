using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class benzinzaman : MonoBehaviour
{
    public float  saniyeb;
    public Text benzinText;
    public GameObject myObject;

    void Start()
    {
        
        saniyeb = 15;
    }

    // Update is called once per frame
    void Update()
    {
        saniyeb -= Time.deltaTime;
        benzinText.text = "Benzin" + ":" + (int)saniyeb;


        if (saniyeb < 0)
        {
            Time.timeScale = 0;

            SceneManager.LoadScene("OyunBitti");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("car") && gameObject.CompareTag("fuel_0")) ||
            (collision.gameObject.CompareTag("fuel_0") && gameObject.CompareTag("car")))
        {
            saniyeb = 15;
        }

    }
}
