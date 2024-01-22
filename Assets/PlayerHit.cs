using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent OnHit;
    public void Hit()
    {
        OnHit?.Invoke();
    }
}
