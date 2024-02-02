using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBornFireRule
{
    public float NeedHealth { get; }
    string Key { get; set; }
    bool IsUnLocked { get;  }
    IBornFireRule Load();
    void Save();
    void OnGUi();
    void OnBornFireGUi();
    void OnTopRightGUI();
    void ReSet();
    // Start is called before the first frame update

}
