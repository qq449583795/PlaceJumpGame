using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovment : MonoBehaviour
{
    // Start is called before the first frame update\
    public float HorizontalSpeed;
    private Rigidbody2D mRigidbody2D;
    private void Awake()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mRigidbody2D.velocity = new Vector2(transform.localScale.x * HorizontalSpeed,
            transform.localScale.y * mRigidbody2D.velocity.y); 
    }
}
