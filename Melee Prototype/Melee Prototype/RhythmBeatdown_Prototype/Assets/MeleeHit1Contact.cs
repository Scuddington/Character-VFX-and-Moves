using UnityEngine;
using System.Collections;

public class MeleeHit1Contact : MonoBehaviour {

    public GameObject impactParticle;
    public Transform impactPoint;
    
    void OnCollisionEnter(Collision collision)
    {
        Instantiate(impactParticle, impactPoint.transform.position, Quaternion.identity);

        //		if (!hasCollided)
        //		{
        //			hasCollided = true;
        //			Destroy (impactParticle);
        //		}
    }
}
