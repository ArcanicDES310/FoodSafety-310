using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour


{

    public Transform player;

    void LateUpdate()
    {

        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -33.37f, 24.72f), transform.position.y, Mathf.Clamp(transform.position.z, -25.9f, 22.3f));

    }

}
