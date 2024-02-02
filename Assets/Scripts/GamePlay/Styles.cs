using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Styles : MonoBehaviour
{
    // Start is called before the first frame update
    public static Lazy<GUIStyle> label = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.label)
    {
        fontSize = 20
    }
    );
    public static Lazy<GUIStyle> button = new Lazy<GUIStyle>(()=>new GUIStyle(GUI.skin.label)
    {
        fontSize = 20
    });
    public static Lazy<GUIStyle> BigLabel = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.label)
    {
        fontSize = 40
    });
}
