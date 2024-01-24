using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBornFireRule
{
    public float NeedHealth { get; }
    string Key { get; set; }
    bool IsUnLocked { get; set; }
    IBornFireRule Load();
    void Save();
    void OnGUi();
    void OnBornFireGUi();
    void OnTopRightGUI();
    // Start is called before the first frame update

}
