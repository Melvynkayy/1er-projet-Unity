using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LookAt : MonoBehaviour
{
    public bool lookAtCamera = false;
    public Transform target;

    void Update() 
    {
        if (target != null) {
            //transform.LookAt(target);
            float x = target.position.x;
            float y = target.position.y + 10;
            float z = target.position.z - 15;
            Camera.main.transform.position = new Vector3(x, y, z);
    
        }

        if (lookAtCamera == true) {
            if (Camera.main != null) {
                transform.LookAt(Camera.main.transform);
            }
        }
    }
}
