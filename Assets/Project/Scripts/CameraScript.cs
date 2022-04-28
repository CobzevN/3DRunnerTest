using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject mainPoint;
    public Vector3 distance;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, mainPoint.transform.position+distance, Time.deltaTime);
    }
}
