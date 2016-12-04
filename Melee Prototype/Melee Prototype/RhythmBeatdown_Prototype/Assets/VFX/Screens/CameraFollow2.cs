using UnityEngine;
using System.Collections;

public class CameraFollow2 : MonoBehaviour {

    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x + 0, player.position.y + 0, -1);
    }
}
