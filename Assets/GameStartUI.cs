using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UTGM;

public class GameStartUI : MonoBehaviour
{
    // Start is called before the first frame update
    private Button mStartBtn;
    private Button mContinueBtn;
    void Start()
    {
        mStartBtn = transform.Find("StartBtn").GetComponent<Button>() ;
        mContinueBtn = transform.Find("ContinueBtn").GetComponent<Button>();
        mContinueBtn.gameObject.SetActive(false);
        mStartBtn.onClick.AddListener(() =>
        {
            ApplePlatformer2D.ReSetGameData();
            SceneManager.LoadScene("Level2");
        });
        if (ApplePlatformer2D.HasContinueGame)
        {
            mContinueBtn.gameObject.SetActive(true);
        }
        mContinueBtn.onClick.AddListener(() =>
        {
            ApplePlatformer2D.ContinueGame();
            SceneManager.LoadScene("Level2");
        });
    }

}
