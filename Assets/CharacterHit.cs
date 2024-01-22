using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHit : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent CharacterHitEvent;

   public void Hit()
    {
        CharacterHitEvent?.Invoke();
    }
}
