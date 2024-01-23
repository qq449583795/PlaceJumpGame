using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : IBornFireRule
{
    public string Key { get ; set ; }
    public bool IsUnLocked { get; set ; }

    public IBornFireRule Load()
    {
        return null;
    }

    public void OnBornFireGUi()
    {
        if (IsUnLocked)
        {
            
        }
        else
        {
            GUILayout.Label("HP ½âËø");
            if (GUILayout.Button("½âËø"))
            {
                IsUnLocked = true;
            }
            
        }
    }

    public void OnGUi()
    {
        if (IsUnLocked)
        {
            GUILayout.BeginArea(new Rect(Screen.width - 200, 0 ,200,200));
            GUILayout.Label("HP: 1/1");
            GUILayout.EndArea();
        }
    }

    public void Save()
    {
    }

    // Start is called before the first frame update
   
}
