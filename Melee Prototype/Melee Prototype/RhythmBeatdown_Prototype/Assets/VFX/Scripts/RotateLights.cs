using UnityEngine;
using System.Collections;

public class RotateLights : MonoBehaviour {

    public float speed = 2f;
    public float maxRotation = 45f;
    public float yValue = 0;
    public float zValue = 0;

    void Update()
    {
        transform.rotation = Quaternion.Euler(maxRotation * Mathf.Sin(Time.time * speed), yValue, zValue);
    }
}
