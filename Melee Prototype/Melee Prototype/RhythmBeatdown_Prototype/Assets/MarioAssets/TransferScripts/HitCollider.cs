using UnityEngine;
using System.Collections;

public class HitCollider : MonoBehaviour {

	public GameObject hitCol;
	public float damage;

	public Fighter owner;
	private Animator anim;
	public GameObject impactParticle;
	// Use this for initialization
	void OnEnable()
	{
		ColReset.resetAction += ResetHitCol;

	}
	void OnDisable()
	{
		ColReset.resetAction -= ResetHitCol;
	}

	void Start () {
		hitCol = this.gameObject;
	}
	
	void OnTriggerEnter(Collider col)
	{
		Fighter opponent = col.gameObject.GetComponent<Fighter> ();
		anim = col.gameObject.GetComponent<Animator> ();
		if (opponent != null && opponent != owner && owner.attacking)
		{
			if (!opponent.gettingHit /* && !opponent.blocking*/) {
				anim.SetTrigger ("TakeHit");
				Instantiate(impactParticle, hitCol.transform.position, Quaternion.identity);
				//hitCol.SetActive (false);
				print ("I hit " + opponent + " with " + hitCol);
			} else if (opponent.blocking) {
				anim.SetTrigger ("BlockHit");
			}
		}
	}

	public void ResetHitCol()
	{
		hitCol.SetActive(true);
		print ("Reset Hit Col");
	}

}

