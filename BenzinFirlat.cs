using System.Collections;
using UnityEngine;

public class BenzinFirlat: MonoBehaviour
{
    public GameObject fuel;
    bool benzinfirlat = true;
    void Start()
    {
        StartCoroutine(bekle());
    }


IEnumerator bekle()
    {
        while(benzinfirlat == true)
        {
            Instantiate(fuel, transform.position,Quaternion.identity);
            yield return new WaitForSecondsRealtime(0.5f);

        }
    }
}
