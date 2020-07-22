using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundUser : MonoBehaviour
{

    public float speed = 2f;
    [SerializeField]
    Transform t;
    // Update is called once per frame
    void Update()
    {
        //rotate around the object t
        transform.RotateAround(t.position, Vector3.up, speed * Time.deltaTime);

    }
}
