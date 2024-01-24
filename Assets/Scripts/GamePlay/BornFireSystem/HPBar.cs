using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTGM;

public class HPBar : IBornFireRule
{
    private Lazy<IPlayerModel> mPlayerModel = new Lazy<IPlayerModel>(() =>

        ApplePlatformer2D.Interface.GetModel<IPlayerModel>()
    );
    public float NeedHealth { get; } = 30f;
    public string Key { get ; set ; }= nameof(HPBar);
    public bool IsUnLocked { get; set ; }

    public IBornFireRule Load()
    {
        return null;
    }

    public void OnBornFireGUi()
    {
        if (!IsUnLocked)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("HP �۸�" + NeedHealth, Styles.label.Value);
            GUILayout.FlexibleSpace();
            if (BornFire.RemainingHealth < NeedHealth)
            {
                GUILayout.Label("ʱ�䲻�㣡",Styles.label.Value);
            }
            else 
            {
                if (BornFire.RemainingHealth > NeedHealth  && GUILayout.Button("����", Styles.button.Value))
                {
                    BornFire.RemainingHealth -= NeedHealth;
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
        if (IsUnLocked)
        {
            GUILayout.Label($"HP: {mPlayerModel.Value.HP}/{mPlayerModel.Value.MaxHP}", Styles.label.Value);
        }
    }

    public void Save()
    {
    }

    // Start is called before the first frame update
   
}
