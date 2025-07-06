using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject random_npc_car;
    bool car_spawn = true;
    void Start()
    {
        StartCoroutine(bekle());
    }

    // Update is called once per frame
IEnumerator bekle()
    {
        while(car_spawn == true)
        {
            Instantiate(random_npc_car, transform.position,Quaternion.identity);
            yield return new WaitForSecondsRealtime(2.5f);

        }
    }
}
