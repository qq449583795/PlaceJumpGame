using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FootTrigger2D : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask TrigerMask;
    private HashSet<Collider2D> m_Colliders = new HashSet<Collider2D>();

    public UnityEvent TriggerEnterEvent;
    public UnityEvent TriggerExitEvent;

    //½Å²Èµ½µØÃæ
    public bool IsTrigger; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMaskUtility.Contains(TrigerMask, collision.gameObject.layer))
        {
            m_Colliders.Add(collision);
            if (!IsTrigger && m_Colliders.Count > 0)
            {
                Debug.Log("OnTriggerEnter2D " +1);
                TriggerEnterEvent?.Invoke();
                IsTrigger = true;
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMaskUtility.Contains(TrigerMask, collision.gameObject.layer) )
        {
            m_Colliders.Remove(collision);
            if (IsTrigger && m_Colliders.Count == 0)
            {
                TriggerExitEvent?.Invoke();
                IsTrigger = false;
            }
           
        }
    }
}
