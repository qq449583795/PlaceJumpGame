using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRemainingTime : MonoBehaviour
{
    // Start is called before the first frame update
    public void Excute(float rewardTime)
    {
        BornFire.RemainingHealth += rewardTime;
    }
}
