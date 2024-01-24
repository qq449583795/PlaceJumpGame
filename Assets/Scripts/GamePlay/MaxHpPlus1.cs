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
            GUILayout.Label("HP���ֵ �۸�" + NeedHealth, Styles.label.Value);
            GUILayout.FlexibleSpace();
            if (BornFire.RemainingHealth < NeedHealth)
            {
                GUILayout.Label("ʱ�䲻�㣡", Styles.label.Value);
            }
            else
            {
                if (BornFire.RemainingHealth > NeedHealth && GUILayout.Button("����", Styles.button.Value))
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
