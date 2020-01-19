using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarMovement : MonoBehaviour
{
    //Default accelerationPower is 25 and steeringPower is 1.
    public float accelerationPower = 25f;
    public float steeringPower = 1f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        float steeringAmount = -Input.GetAxis("Horizontal");
        float speed = Input.GetAxis("Vertical") * accelerationPower;
        float direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += steeringAmount/2 * steeringPower * rb.velocity.magnitude * direction;
        //Movement forward
        rb.AddRelativeForce(Vector2.up * speed);
        //Change rotation
        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
    }

}
