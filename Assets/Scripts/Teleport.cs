using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : GazeableObject
{
    public override void OnPress(RaycastHit hitInfo)
    {
        base.OnPress(hitInfo);

        if (Player.instance.activeMode == InputMode.TELEPORT)
        {
            Vector3 destLocation = new Vector3(-5.23f, 1.08f, -7.89f);
            destLocation.y = Player.instance.transform.position.y;

            Player.instance.transform.position = destLocation;
        }
    }
}
