using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benzinalma : MonoBehaviour

{
    public benzinzaman script;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fuel_0"))
        {
            Destroy(collision.gameObject);
            script.saniyeb = 15;
        }
    }
}