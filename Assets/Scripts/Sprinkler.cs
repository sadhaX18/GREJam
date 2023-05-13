using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkler : MonoBehaviour
{
    [SerializeField]
    private GameObject water;
    [SerializeField]
    private Transform[] sprinklers;

    [SerializeField]
    float delayAndSpawnRate = 1.5f;
    [SerializeField]
    float eachStageDuration = 30;
    [SerializeField]
    float speedIncrements = 0.5f;
    [SerializeField]
    int stages = 3;
    void Start()
    {
        InvokeRepeating("SpawnObject", delayAndSpawnRate, delayAndSpawnRate);
        StartCoroutine(Schedule());
    }
    public void SpawnObject()
    {
        System.Random rand = new System.Random();
        Instantiate(water, sprinklers[rand.Next(sprinklers.Length)]);
    }

    void IncreaseSpawnRate()
    {
        if (delayAndSpawnRate > speedIncrements)
        {
            delayAndSpawnRate -= speedIncrements;
        }
    }
    IEnumerator Schedule()
    {
        yield return new WaitForSeconds(eachStageDuration);
        if (stages>1)
        {
            stages--;
            IncreaseSpawnRate();
            StartCoroutine(Schedule());
        }
        else
        {
            CancelInvoke("SpawnObject");
        }
        
    }
}

    

