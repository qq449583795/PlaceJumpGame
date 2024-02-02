using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReBornEnemy : IBornFireRule
{
    // Start is called before the first frame update
    public float NeedHealth { get; } = 5f;

    public string Key { get; set; } = nameof(ReBornEnemy);
    public bool IsUnLocked { get; private set ; }

    public void Save()
    {
        PlayerPrefs.SetInt(nameof(ReBornEnemy), IsUnLocked ? 1 : 0);
    }
    public IBornFireRule Load()
    {
        IsUnLocked = PlayerPrefs.GetInt(nameof(ReBornEnemy),0) == 1 ? true : false;
        return null;
    }

    public void OnBornFireGUi()
    {
        if (!IsUnLocked)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("打开火堆重生敌人 价格：" + NeedHealth, Styles.label.Value);
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

    public void ReSet()
    {
        IsUnLocked = false;
    }

}
