using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAfterTime : MonoBehaviour
{

    float timer;
    float lifetime;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    // Start is called before the first frame update
    void Start()
    {
        lifetime = Random.Range(minTime, maxTime);
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
