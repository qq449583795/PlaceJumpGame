using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UTGM
{
    public class GlobalMonoEvent : MonoBehaviour
    {
        // Start is called before the first frame update
        public static EasyEvent OnApplicationQuitEvent = new EasyEvent();
        [RuntimeInitializeOnLoadMethod]
        public static void Initialize()
        {
            GameObject globalMonoEvent = new GameObject("GlobalMonoEvent");
            globalMonoEvent.AddComponent<GlobalMonoEvent>();
            DontDestroyOnLoad(globalMonoEvent);
        }
        private void OnApplicationQuit()
        {
            OnApplicationQuitEvent?.Trigger();
        }
    }
}


