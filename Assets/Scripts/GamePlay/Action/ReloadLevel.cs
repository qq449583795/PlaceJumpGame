using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void Execute()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
