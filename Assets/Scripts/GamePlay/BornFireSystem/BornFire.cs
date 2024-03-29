using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UTGM;

public class BornFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BornText;
    private bool mPlayerEnter;
    private bool mPlayerPress;

    private IBornFireSystem bornFireSystem;
    private void Awake()
    {

        bornFireSystem = ApplePlatformer2D.Interface.GetSystem<IBornFireSystem>();

    }
    private void Update()
    {
        RemainingHealth -= Time.deltaTime;
        if (RemainingHealth<0)
        {
            ApplePlatformer2D.IsGameOver = true;
        }
        if (mPlayerEnter)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                ApplePlatformer2D.OnOpenBornFireUI.Trigger();
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
    public static float RemainingHealth = 60;
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width - 200, 0, 200, 200));
        GUILayout.Label("当前剩余寿命：" + (int)RemainingHealth, Styles.label.Value);
        foreach (var fireRule in bornFireSystem.BornFireRuleList)
        {
            fireRule.OnTopRightGUI();
        }
        GUILayout.EndArea();
        foreach (var fireRule in bornFireSystem.BornFireRuleList)
        {
            fireRule.OnGUi();
        }
        if (mPlayerPress)
        {
           
            GUILayout.Label("进入火堆", Styles.label.Value);
            foreach (var fireRule in bornFireSystem.BornFireRuleList)
            {
                fireRule.OnBornFireGUi();
            }
        }
        if (ApplePlatformer2D.IsGameOver)
        {
            GUILayout.BeginArea(new Rect(0, Screen.height * 0.5f, Screen.width, Screen.height));
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("游戏结束", Styles.BigLabel.Value);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("重新开始", Styles.BigLabel.Value))
                {
                    ApplePlatformer2D.ReSetGameData();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                if (GUILayout.Button("回到主界面", Styles.BigLabel.Value))
                {
                    ApplePlatformer2D.ReSetGameData();
                    SceneManager.LoadScene("GameStart");
                }
                GUILayout.FlexibleSpace();
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
        
    }
}
