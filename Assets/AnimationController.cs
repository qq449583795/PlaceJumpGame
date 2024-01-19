using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    private PlayerController playerController;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = 0.3f * (Mathf.Abs(rigidbody2D.velocity.x)/ playerController.HorizontalSpeed);
        transform.localScale = new Vector3(1f + offset, 0.7f + 0.3f,1); 
    }
}
