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

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -42.5f, 32f), transform.position.y, Mathf.Clamp(transform.position.z, -26f, 22.2f));

    }

}
