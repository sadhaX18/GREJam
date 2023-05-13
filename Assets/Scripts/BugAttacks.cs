using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAttacks : MonoBehaviour
{
    public Sprite[] sprites;
    int plantstate;

    SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        plantstate = 0;
    }

    private void Update()
    {
        sp.sprite = sprites[plantstate];
        if (plantstate > 4)
        {
            Application.Quit();
            Debug.Log("Your Plant has been destroyed");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BadBug")
            plantstate++;
    }
}
