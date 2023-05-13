using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Sprinkler : MonoBehaviour
{
    [SerializeField]
    private GameObject water;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SpawnWater()
    {
        animator.SetBool("SprinklerState", true);
        StartCoroutine("WaterDrop");
    }

    IEnumerator WaterDrop()
    {
        yield return new WaitForSeconds(2);
        Instantiate(water, transform);
        animator.SetBool("SprinklerState", false);
    }
}
