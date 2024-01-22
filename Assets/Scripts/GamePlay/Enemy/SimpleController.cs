using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterMovment mMovement;
    //检测脚底下没有地面
    public FootTrigger2D FootTrigger;
    //检测前方有没有墙
    public FootTrigger2D ForwardTrigger;
    //检测前方有没有地面
    public FootTrigger2D GroundTrigger;
    //检测攻击
    public FootTrigger2D AttackTrigger;

    public float KillPlayerHorizontalForce;
    public float KillPlayerVertForce;

    private void Awake()
    {
        mMovement = GetComponent<CharacterMovment>();
        mMovement.enabled = false;
        FootTrigger.TriggerEnterEvent.AddListener(() =>
        {
            mMovement.enabled = true;
        });

     
        ForwardTrigger.TriggerEnterEvent.AddListener(() =>
        {
            transform.localScale = -1 * transform.localScale;
        });

       
        GroundTrigger.TriggerExitEvent.AddListener(() =>
        {
            transform.localScale = -1* transform.localScale;
        });

        AttackTrigger.TriggerEnterWithColliderEvent.AddListener((collider) =>
        {
            if (collider.CompareTag("Player")) {
                collider.GetComponent<PlayerHit>().Hit();
                collider.GetComponent <PlayerController>().enabled = false;
                AttackPlayer(collider);
            }
        });
        AttackTrigger.TriggerEnterWithColliderEvent.AddListener((collider) =>
        {
            
        });
    }
    private void AttackPlayer(Collider2D collider)
    {
        float directionForce = collider.transform.position.x - transform.position.x;
        directionForce = Mathf.Sign(directionForce);
        Rigidbody2D playerRb = collider.GetComponent<Rigidbody2D>();
        playerRb.velocity = new Vector2(directionForce * KillPlayerHorizontalForce, KillPlayerVertForce);
    }
}
