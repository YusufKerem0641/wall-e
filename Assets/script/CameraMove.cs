using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform palyerTransform1;
    public Transform palyerTransform2;
    public Transform palyerTransform3;
    private Transform cameraTransform;
    void Start()
    {
        cameraTransform = transform.GetComponent<Transform>();
    }

    void Update()
    {
        if (palyerTransform1 != null)
            cameraTransform.position = new Vector3(palyerTransform1.position.x, palyerTransform1.position.y , cameraTransform.position.z);
        else if (palyerTransform2 != null)
            cameraTransform.position = new Vector3(palyerTransform2.position.x, palyerTransform2.position.y, cameraTransform.position.z);
        else if (palyerTransform3 != null)
            cameraTransform.position = new Vector3(palyerTransform3.position.x, palyerTransform3.position.y, cameraTransform.position.z);
    }
}
