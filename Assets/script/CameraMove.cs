using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform palyerTransform;
    private Transform cameraTransform;
    void Start()
    {
        cameraTransform = transform.GetComponent<Transform>();
    }

    void Update()
    {
        cameraTransform.position = new Vector3(palyerTransform.position.x, palyerTransform.position.y , cameraTransform.position.z);
    }
}
