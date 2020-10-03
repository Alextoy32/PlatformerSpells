using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public Transform playerPosition;
    public Transform myPosition;

    // Update is called once per frame
    void Update()
    {
        var camPos = new Vector3(playerPosition.position.x + 3, myPosition.position.y, myPosition.position.z);
        myPosition.SetPositionAndRotation(camPos, myPosition.rotation);
    }
}
