using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UTGM;

public class MinusHP : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent OnFinishAction;
    public void Execute()
    {
        IPlayerModel model= ApplePlatformer2D.Interface.GetModel<IPlayerModel>();
        model.HP--;
        if (model.HP<=0)
        {
            ApplePlatformer2D.IsGameOver = true;
            OnFinishAction?.Invoke();
        }
    }
}
