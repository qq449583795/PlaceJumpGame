using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Apple : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent OnGetReward;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnGetReward?.Invoke();
        Destroy(gameObject);
    }

}
