using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform BallTransform;
    public bool GameOver=false;

    
    void Start()
    {
        
    }


    void Update()
    {
        if (!GameOver)
        {
            Vector3 DeserdPosition = new Vector3(transform.position.x, BallTransform.position.y + 6, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, DeserdPosition, 2f * Time.deltaTime);
        }
    }
}
