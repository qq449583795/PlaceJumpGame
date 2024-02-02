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
    public void ReSet()
    {
        IsUnLocked = false;
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
        PlayerPrefs.SetInt(nameof(HPBar),IsUnLocked ?1:0);
    }
    public IBornFireRule Load()
    {
        IsUnLocked = PlayerPrefs.GetInt(nameof(HPBar),0) == 1 ? true : false;
        return null;
    }
    // Start is called before the first frame update

}
