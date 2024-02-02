using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UTGM;

public class BornFireUnlockCondition : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent OnOpenFireEvent;
    public string key;
    public void Execute()
    {
        IBornFireRule rule = ApplePlatformer2D.Interface.GetSystem<IBornFireSystem>().GetRulByKey(key);
        if (rule.IsUnLocked)
        {
            OnOpenFireEvent?.Invoke();
        }
    }
}
