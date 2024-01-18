using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.K))
        {
            rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, 5f));
        }
        rigidbody2D.AddForce(new Vector2(horizontal, rigidbody2D.velocity.y));
    }
}
