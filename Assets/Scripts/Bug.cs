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

    
}