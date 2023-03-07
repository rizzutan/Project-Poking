using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyForce : MonoBehaviour
{
    public float gravityAcc = 3;
    public float gravity = 9;
    private bool gravityFlipped = false;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gravityFlipped)
        {
            rb.AddForce(Vector2.up * gravityAcc, ForceMode.Impulse);
        }
        rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -gravity, gravity), rb.velocity.z);
    }

    public void FlipGravity()
    {
        gravityFlipped = !gravityFlipped;
    }
}
