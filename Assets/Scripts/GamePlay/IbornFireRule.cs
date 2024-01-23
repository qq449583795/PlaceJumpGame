using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBornFireRule 
{
    string Key { get; set; }
    bool IsUnLocked { get; set; }
    IBornFireRule Load();
    void Save();
    void OnGUi();
    void OnBornFireGUi();
    // Start is called before the first frame update

}
