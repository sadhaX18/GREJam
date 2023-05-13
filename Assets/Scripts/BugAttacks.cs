using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAttacks : MonoBehaviour
{
    public Sprite[] sprites;
    int plantstate;
    int criteria;

    SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        plantstate = 0;
        criteria = 0;
    }

    private void Update()
    {
        sp.sprite = sprites[plantstate];
        if (plantstate > 4)
        {
            Debug.Log("Your Plant has been destroyed");
            Application.Quit();
        }
        if(criteria > 2)
        {
            Debug.Log("You have sprouted a new plant");
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(plantstate + " " + criteria);
        if (collision.tag == "BadBug")
            plantstate = plantstate >= 5 ? 5 : plantstate++;

        if (collision.tag == "GoodBug")
            plantstate = plantstate <= 0 ? criteria++ : plantstate--;
    }
}
