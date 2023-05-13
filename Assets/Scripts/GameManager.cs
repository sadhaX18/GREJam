using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Sprinkler sprinkler;
    Timer timer;

    public Text Clock;



    // Start is called before the first frame update
    void Start()
    {
        sprinkler = GetComponent<Sprinkler>();
        timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
