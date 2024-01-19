
using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D mRigidbody2D;
    public float JumpUpGravity;
    public float JumpDownGravity;
    public float HorizontalSpeed;
    public float JumpSpeed;

    public UnityEvent OnJumpDown;
    public UnityEvent OnJumpUp;

    private void Awake()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
       
        if (Input.GetKeyDown(KeyCode.Space)&& mCollisionCount>0)
        {
            OnJumpUp?.Invoke();
            mRigidbody2D.velocity = new Vector2(mRigidbody2D.velocity.x, JumpSpeed);
        }
        mRigidbody2D.velocity = new Vector2(HorizontalSpeed* horizontal, mRigidbody2D.velocity.y);
        if (mRigidbody2D.velocity.y > 0)
        {
            mRigidbody2D.gravityScale = JumpUpGravity;
        }
        else
        {
            mRigidbody2D.gravityScale = JumpDownGravity;
        }
    }
    private int mCollisionCount = 0 ;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnJumpDown?.Invoke();
        mCollisionCount ++;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        mCollisionCount --;
    }
}
