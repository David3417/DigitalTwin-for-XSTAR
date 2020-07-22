using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeableObject : MonoBehaviour
{
    public virtual void OnGazeEnter(RaycastHit hitInfo)
    {
        Debug.Log("Gaze entered on " + gameObject.name);
    }

    public virtual void OnGaze(RaycastHit hitInfo)
    {
        Debug.Log("Gaze hold on " + gameObject.name);

    }

    public virtual void OnGazeExit()
    {
        Debug.Log("Gaze exited on  " + gameObject.name);
    }

    public virtual void OnPress(RaycastHit hitInfo)
    {
        Debug.Log("Button pressed");
    }

    public virtual void OnHold(RaycastHit hitInfo)
    {
        Debug.Log("Button hold");
    }

    public virtual void OnRelease(RaycastHit hitInfo)
    {
        Debug.Log("Button released");
    }
}