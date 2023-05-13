using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PotScript : MonoBehaviour
{

    private bool dragging = false;
    private Vector3 offset = Vector3.zero;

    PlantScript plant;

    // Start is called before the first frame update
    void Start()
    {
        plant = GameObject.FindGameObjectWithTag("Plant").GetComponent<PlantScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            transform.position = new Vector3((Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset).x, transform.position.y, transform.position.z);
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
            plant.AddWater();
            plant.UpdateState();
        }
    }
}
