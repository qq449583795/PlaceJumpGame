using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PassGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PassGameUI;
    public UnityEvent OnPassLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PassGameUI.SetActive(true);
            StartCoroutine(ReLoadScene());
        }
    }
    IEnumerator ReLoadScene()
    {
        OnPassLevel?.Invoke();
        yield return new WaitForSeconds(2);
        yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
