using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioSource : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource m_AudioSource;
    void Start()
    {
        m_AudioSource = transform.GetChild(0).GetComponent<AudioSource>();
        m_AudioSource.transform.SetParent(null);
    }

    public void PlayOnceAudio()
    {
        if (m_AudioSource!=null)
        {
            m_AudioSource.Play();
            Invoke("DestroySelf", 1f);
        }
    }
    private void DestroySelf()
    {
        Destroy(m_AudioSource.gameObject);
        Destroy(gameObject);
    }
}
