using UnityEngine;

public class BugManagers : MonoBehaviour
{
    public GameObject goodbug;
    public GameObject badbug;

    float t;

    private void Start()
    {
        t = 1f;
    }
    private void Update()
    {
        if (timer())
        {
            if (Random.value > 0.8) Instantiate(goodbug, new Vector3(Random.Range(1, transform.localScale.x) - transform.localScale.x / 2, Random.Range(1, transform.localScale.y / 2), 0), Quaternion.identity);
            else Instantiate(badbug, new Vector3(Random.Range(1, transform.localScale.x) - transform.localScale.x / 2, Random.Range(1, transform.localScale.y / 2), 0), Quaternion.identity);
        }
    }

    bool timer()
    {
        if (t > 0)
        {
            t -= Time.deltaTime;
            return false;
        }
        else
        {
            t = Random.Range(1, 2);
            return true;
        }
    }
}