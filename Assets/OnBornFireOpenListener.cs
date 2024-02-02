using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UTGM;
namespace UTGM
{
    public class OnBornFireOpenListener : MonoBehaviour
    {
        // Start is called before the first frame update
        public UnityEvent OnBornFireOpenEvent;
        void Start()
        {
            ApplePlatformer2D.OnOpenBornFireUI.Register(() =>
            {
                OnBornFireOpenEvent?.Invoke();
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

