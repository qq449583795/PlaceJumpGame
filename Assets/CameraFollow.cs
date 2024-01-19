using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.y = Player.transform.position.y+2;
        cameraPos.x = Player.transform.position.x;
        transform.position = cameraPos;
    }
}
