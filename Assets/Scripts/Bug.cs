using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    public Transform plant;

    private void Start()
    {
        plant = GameObject.FindGameObjectWithTag("Plant").transform;
    }

    private void Update()
    {
        transform.Translate((plant.position - transform.position).normalized * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
            Destroy(this.gameObject);
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
            Destroy(this.gameObject);
    }
}
