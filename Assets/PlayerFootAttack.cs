using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public FootTrigger2D AttackTrigger;
    private Rigidbody2D rigidbody2D;
    public float KillEnemyForce;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        AttackTrigger.TriggerEnterWithColliderEvent.AddListener((collider) =>
        {
            if (collider.CompareTag("Enemy"))
            {
                rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x, KillEnemyForce);
                collider.GetComponent<CharacterHit>().Hit();
            }
        });


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
