using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent OnSpikeEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnSpikeEvent?.Invoke();
            StartCoroutine(ReLoadScene());
        }
    }
    IEnumerator ReLoadScene()
    {
        yield return new WaitForSeconds(1);
        yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
