using System.Runtime.CompilerServices;
using UnityEngine;

public class benzinpozisyon : MonoBehaviour
{
    Rigidbody2D rb;
    private int benzin_serit;
    public Sprite fuel_0;
    public int fuel_sprite;
    SpriteRenderer spr;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        benzin_serit = Random.RandomRange(1, 5);

        if (benzin_serit == 1)
        {
            transform.position = new Vector2(-3.75f, transform.position.y + 7);
        }
        else if (benzin_serit == 2)
        {
            transform.position = new Vector2(-1.32f, transform.position.y + 7);
        }
        else if (benzin_serit == 3)
        {
            transform.position = new Vector2(1.26f, transform.position.y + 7);
        }
        else if (benzin_serit ==4)
        {
            transform.position = new Vector2(3.86f, transform.position.y + 7);
        }

        fuel_sprite = 1;
        spr.sprite = fuel_0;
       
    }

    
    void Update()
    {
        
    }
}
