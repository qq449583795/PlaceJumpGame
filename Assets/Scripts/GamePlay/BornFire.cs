using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BornText;
    private bool mPlayerEnter;
    private bool mPlayerPress;
    private void Awake()
    {
        mFireRuleList = new List<IBornFireRule> ();
        mFireRuleList.Add(new HPBar());

    }
    private void Update()
    {
        if (mPlayerEnter)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                mPlayerPress = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mPlayerEnter = true;
            BornText.SetActive(mPlayerEnter);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mPlayerEnter = false;
            BornText.SetActive(mPlayerEnter);
            mPlayerPress = false;
        }
    }
    private List<IBornFireRule> mFireRuleList;
    private void OnGUI()
    {
        if (mPlayerPress)
        {
           
            GUILayout.Label("½øÈë»ð¶Ñ");
            foreach (var fireRule in mFireRuleList)
            {
                fireRule.OnGUi();
                fireRule.OnBornFireGUi();
            }
        }
    }
}
