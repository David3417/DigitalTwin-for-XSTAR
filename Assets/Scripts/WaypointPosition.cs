using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPosition : MonoBehaviour
{
   //[Header("This is the list of Waypoint Positions.")]
    [Header("To add a new Waypoint Position:")]
    [Header("1. Create a new empty gameobject ")]
    [Header("2. Set the position and rotation")]
    [Header("3. Drag it from the Hierarchy to the Waypoint Positions list")]
    [Space]

    [Tooltip("List of Waypoint positions")]
    public List<Transform> waypointPositions;

    int currentPosition;//Position the player is currently at
    bool shouldTeleport;//A true/false variable to see whether or not we should move to a new location
    public float teleportSpeed = 100f;//A variable to see how fast we are moving

    // Use this for initialization
    void Start()
    {
        currentPosition = 0;//ensure we are starting at the first position in the list
        shouldTeleport = true;//move to the first position if not there already

        Vector3 destLocation = new Vector3(-0.23f, 1.55f, -0.7f);
        destLocation.y = Player.instance.transform.position.y;

        Player.instance.transform.position = destLocation;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 70, 100, 50), "Previous"))
        {
            TeleportToPreviousWaypoint();
        }

        if (GUI.Button(new Rect(0, 140, 100, 50), "Next"))
        {
            TeleportToNextWaypoint();
        }
    }

 
    /// <summary>
    /// Teleports to the specified waypoint. Useful for teleporting directly to a certain waypoint.
    /// </summary>
    /// <param name="waypointNum">Index of the waypoint (from the Waypoint Positions list) you'd like to teleport to</param>
    public void TeleportToWaypoint(int waypointNum)
    {
        currentPosition = waypointNum;
        shouldTeleport = true;
    }

    /// <summary>
    /// Teleports to next waypoint in the Waypoint Positions list
    /// If you reach the end of the list, it will loop to the beginning
    /// </summary>
    public void TeleportToNextWaypoint()
    {
        shouldTeleport = true;
        currentPosition = (currentPosition + 1) % waypointPositions.Count;
    }

    /// <summary>
    /// Teleports to previous waypoint in the Waypoint Positions list.
    /// If you reach the beginning of the list, it will loop you to the end
    /// </summary>
    public void TeleportToPreviousWaypoint()
    {
        shouldTeleport = true;
        currentPosition -= 1;
        if (currentPosition < 0)
        {
            currentPosition = waypointPositions.Count - 1;
        }

        HandleTeleport();
    }

    //Update is executed once per frame
    void Update()
    {
        if (shouldTeleport)
        {
            HandleTeleport();
        }

//        HandleOVRInput();
    }

/*    /// <summary>
    /// Handles input from the Oculus Controller.
    /// </summary>
    void HandleOVRInput()
    {
        //if we swipe right on the Oculus Controller we will move upwards through the positions
        if (OVRInput.Get(OVRInput.Button.Right))
        {
            TeleportToNextWaypoint();
        }

        //if we swipe left on the Oculus Controller we will move upwards through the positions
        if (OVRInput.Get(OVRInput.Button.Left))
        {
            TeleportToPreviousWaypoint();
        }
    }
*/
    /// <summary>
    /// Handles the teleport. This method is ran over multiple frames to create a smooth transition between waypoint positions.
    /// </summary>
    void HandleTeleport()
    {

        transform.rotation = waypointPositions[currentPosition].rotation;
        transform.position = Vector3.MoveTowards(transform.position, waypointPositions[currentPosition].position, teleportSpeed * Time.deltaTime);

        if (transform.position == waypointPositions[currentPosition].position)
        {
            shouldTeleport = false;
        }
    }
}
