using UnityEngine;
using System.Collections;

public class ProjectileScript2 : MonoBehaviour
{
    public GameObject impactParticle;
    public GameObject projectileParticle;
    public GameObject[] trailParticles;
    [HideInInspector]
    public Vector3 impactNormal; //Used to rotate impactparticle.

    private bool hasCollided = false;

    void Start()
    {
        projectileParticle = Instantiate(projectileParticle, transform.position, transform.rotation) as GameObject;
        projectileParticle.transform.parent = transform;
    }

    void OnCollisionEnter(Collision hit)
    {
        if (!hasCollided) {
            hasCollided = true;
            print("Collided");

            //instantiate impact particle upon collision
            impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.left, impactNormal)) as GameObject;

            //destroy upon collision
            Destroy(projectileParticle, 0.2f);
            Destroy(impactParticle, 0.2f);
            Destroy(gameObject);
            print("destroyed");
        }
    }
}