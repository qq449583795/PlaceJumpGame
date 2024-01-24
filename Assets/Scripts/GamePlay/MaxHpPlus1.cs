using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTGM;

public class MaxHpPlus1 : IBornFireRule
{
    private Lazy<IPlayerModel> mPlayerModel = new Lazy<IPlayerModel>(() =>

        ApplePlatformer2D.Interface.GetModel<IPlayerModel>()
    );
    // Start is called before the first frame update
    private Lazy<IBornFireRule> mHpBar = new Lazy<IBornFireRule>(() =>
        ApplePlatformer2D.Interface.GetSystem<IBornFireSystem>().GetRulByKey(nameof(HPBar))

    );
    public string Key { get; set; } = nameof(MaxHpPlus1);
    public bool IsUnLocked { get; set ; }

    public float NeedHealth { get; } = 10f;

    public IBornFireRule Load()
    {
        return null;
    }

    public void OnBornFireGUi()
    {
        if (!IsUnLocked&& mHpBar.Value.IsUnLocked)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("HP最大值 价格：" + NeedHealth, Styles.label.Value);
            GUILayout.FlexibleSpace();
            if (BornFire.RemainingHealth < NeedHealth)
            {
                GUILayout.Label("时间不足！", Styles.label.Value);
            }
            else
            {
                if (BornFire.RemainingHealth > NeedHealth && GUILayout.Button("解锁", Styles.button.Value))
                {
                    BornFire.RemainingHealth -= NeedHealth;
                    mPlayerModel.Value.HP++;
                    mPlayerModel.Value.MaxHP++;
                    IsUnLocked = true;
                }
            }
            GUILayout.EndHorizontal();


        }
    }

    public void OnGUi()
    {
        
    }

    public void OnTopRightGUI()
    {
        
    }

    public void Save()
    {
        
    }
}
