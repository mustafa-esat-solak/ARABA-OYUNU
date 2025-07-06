using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private float varsayilan_hiz;
    Rigidbody2D rb;
    private int gidilen_serit;
    public Sprite car1, car2, car3, car4, car5, car6, car7, car8;
    public int car_sprite;
    SpriteRenderer spr;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        varsayilan_hiz = Random.RandomRange(10f, 15f);

        gidilen_serit = Random.RandomRange(1, 5);

        if (gidilen_serit == 1)
        {
            transform.position = new Vector2(-3.75f, transform.position.y+7);
        }
        else if (gidilen_serit == 2)
        {
            transform.position = new Vector2(-1.32f, transform.position.y+7);
        }
        else if (gidilen_serit == 3)
        {
            transform.position = new Vector2(1.26f, transform.position.y+7);
        }
        else if (gidilen_serit == 4)
        {
            transform.position = new Vector2(3.86f, transform.position.y+7);
        }

        car_sprite = Random.RandomRange(1, 9);

        switch (car_sprite)
        {
                case 1:
                spr.sprite = car1;
                break;
                case 2: spr.sprite = car2;
                break;
                case 3: spr.sprite = car3;
                break;
                case 4: spr.sprite = car4;
                break;
                case 5: spr.sprite = car5;
                break;
                case 6: spr.sprite = car6;
                break;
                case 7: spr.sprite = car7;
                break;
                case 8: spr.sprite = car8;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, varsayilan_hiz*50*Time.deltaTime);

    }
}
