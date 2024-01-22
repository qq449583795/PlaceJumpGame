using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRootParent : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Execute();
    }
    public void Execute()
    {
        transform.SetParent(null);
    }

}
