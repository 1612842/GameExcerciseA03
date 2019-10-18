using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public float xMax;
    public float yMax;
    public float xMin;
    public float yMin;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("mario_0").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax),
            Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
    }
}
