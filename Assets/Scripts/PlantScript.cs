using System;
using UnityEngine;

// Attach this script to a GameObject with a Collider, then mouse over the object to see your cursor change.
public class PlantScript : MonoBehaviour
{
    // Script for mouse behaviour

    //public Texture2D cursorTexture;
    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot = Vector2.zero;

    //void OnMouseEnter()
    //{
    //    Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    //}

    //void OnMouseExit()
    //{
    //    // Pass 'null' to the texture parameter to use the default system cursor.
    //    Cursor.SetCursor(null, Vector2.zero, cursorMode);
    //}

    private bool dragging = false;
    private Vector3 offset = Vector3.zero;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private int water = 0;
    void Update()
    {
        if(dragging)
        {
            transform.position = new Vector3((Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset).x,transform.position.y,transform.position.z);
        }
    }
    private void OnMouseDown()
    {
        dragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseUp()
    {
        dragging = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            Destroy(collision.gameObject);
            water = water + 1;
            UpdateState();
        }
    }
    private void UpdateState()
    {
        transform.localScale = new Vector3(transform.localScale.x, (transform.localScale.y + 0.2f), transform.localScale.z);
        if(water > 5)
        {
            spriteRenderer.color = Color.green;
        }
        else if(water > 3)
        {
            spriteRenderer.color = Color.yellow;
        }
        
    }
}