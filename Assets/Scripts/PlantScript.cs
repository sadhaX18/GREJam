using System;
using UnityEngine;

// Attach this script to a GameObject with a Collider, then mouse over the object to see your cursor change.
public class PlantScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] plant;
    private int plantState = 0;

    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCollider;

    float[,] colliderSettings = new float[12, 5] {
        { 0.2f, 0.5f, 0.1f, -0.5f, 0.0f },
        { 1.0f, 0.4f, -0.1f, -0.5f, 1.0f },
        { 1.4f, 0.5f, -0.35f, -0.5f, 1.0f },
        { 1.4f, 0.5f, -0.35f, -0.5f, 1.0f },
        { 1.4f, 0.5f, -0.35f, -0.5f, 1.0f },
        { 1.4f, 0.5f, -0.35f, -0.5f, 1.0f },
        { 0.2f, 0.5f, 0.4f, 0.5f, 1.0f },
        { 0.2f, 0.5f, 0.4f, 0.5f, 1.0f },
        { 0.2f, 0.5f, 0.4f, 0.5f, 0.0f },
        { 0.2f, 0.5f, 0.4f, 0.5f, 1.0f },
        { 0.2f, 0.5f, 0.2f, 0.5f, 1.0f },
        { 0.2f, 0.5f, 0.2f, 0.5f, 0.0f } };

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        UpdateState();
    }
    private int water = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            Destroy(collision.gameObject);
            water = water + 1;
            UpdateState();
        }
    }
    public void UpdateState()
    {
        plantState = water;
        if (plant[plantState] != null)
        {
            spriteRenderer.sprite = plant[water];
            capsuleCollider.size= new Vector2(colliderSettings[plantState,0], colliderSettings[plantState,1]);
            capsuleCollider.offset = new Vector2(colliderSettings[plantState,2], colliderSettings[plantState,3]);
            capsuleCollider.direction = (colliderSettings[plantState, 4] == 0.0f) ? CapsuleDirection2D.Vertical : CapsuleDirection2D.Horizontal;
        }
        
    }
    public void AddWater()
    {
        water = water + 1;
    }
}