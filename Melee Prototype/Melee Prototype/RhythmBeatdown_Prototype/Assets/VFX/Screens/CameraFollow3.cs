using UnityEngine;
using System.Collections;

public class CameraFollow3 : MonoBehaviour {

    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x - 0.25f, player.position.y + 1.75f, -10);
    }
}
