using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimeUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text LevelTimeText;

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount%20 ==0)
        {
            LevelTimeText.text = ((int)Time.time).ToString();
        }
    }
}
