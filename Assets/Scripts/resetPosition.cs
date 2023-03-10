using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPosition : MonoBehaviour
{
    public Vector3 reset;

    // Start is called before the first frame upda

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = reset;
    }
}
