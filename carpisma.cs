using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class carpisma : MonoBehaviour
{
    private Scene _scene;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("car"))
        {
            SceneManager.LoadScene("OyunBitti");
        }
    }
}
