
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using static PlayerController;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D mRigidbody2D;
    public float JumpGrivityMultiplier = 1.0f;
    public float FallGrivityMultiplier = 2.0f;
    public float HorizontalSpeed;
    public float JumpSpeed;
    private bool isPressBtn;
    //玩家脚下的trigger  判断踩到地板
    private FootTrigger2D mFootTrigger2D;

    private void Awake()
    {
        mFootTrigger2D = transform.GetChild(0).GetComponent<FootTrigger2D>();
        mRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private float mHorizontal;
    private void Update()
    {
        mHorizontal = Input.GetAxis("Horizontal");
        //
        if (Input.GetKeyDown(KeyCode.Space) && mFootTrigger2D.IsTrigger)
        {
           
            if (jumpStat == JumpStats.NotJump)
            {
                mJumpTime = 0;
                jumpStat = JumpStats.MinJump;
                isPressBtn = true;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isPressBtn=false;
        }
        mJumpTime += Time.deltaTime;
        
        
    }
    public enum JumpStats{
        NotJump,
        MinJump,
        ControlJump
    }
    private JumpStats jumpStat = JumpStats.NotJump;
    public float mMinJumpTime = 0.3f;
    public float mMaxJumpTime= 1f;
    private float mJumpTime;
    public float Progress;

    private void FixedUpdate()
    {
        if (jumpStat == JumpStats.MinJump)
        {
            mRigidbody2D.velocity = new Vector2(mRigidbody2D.velocity.x, JumpSpeed);
            if (mJumpTime> mMinJumpTime)
            {
                jumpStat = JumpStats.ControlJump;
            }
        }
        else if (jumpStat == JumpStats.ControlJump)
        {
            mRigidbody2D.velocity = new Vector2(mRigidbody2D.velocity.x, JumpSpeed);
            if (!isPressBtn || mJumpTime > mMaxJumpTime&& isPressBtn)
            {
                jumpStat = JumpStats.NotJump;
            }
        }
        mRigidbody2D.velocity = new Vector2(HorizontalSpeed * mHorizontal, mRigidbody2D.velocity.y);
        if (mRigidbody2D.velocity.y > 0 && jumpStat!=JumpStats.NotJump)
        {
            float progress = mJumpTime / mMaxJumpTime ;
            float curJumpGrivityMultiplier = JumpGrivityMultiplier;
            if (progress > 0.5f)
            {
                curJumpGrivityMultiplier = curJumpGrivityMultiplier * (1 - progress);
            }
            mRigidbody2D.velocity += Physics2D.gravity * curJumpGrivityMultiplier * Time.deltaTime;
        }
        else if(mRigidbody2D.velocity.y < 0 )
        {
            mRigidbody2D.velocity += Physics2D.gravity * FallGrivityMultiplier * Time.deltaTime;
        }
    }
    
}
