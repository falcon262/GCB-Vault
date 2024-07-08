using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        CameraLogic();
    }

    void CameraLogic()
    {
        //transform.LookAt(target.transform.position);
        transform.position = target.position + offset;
        transform.forward = target.forward;
    }
}
