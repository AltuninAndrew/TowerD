using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public Transform distanation { get; set; }
    public float speed { get; set; }
    public float damage { get; set; }
    private Vector3 targ;
	void Update () {
        if(distanation!=null)
        {
            targ = new Vector3(distanation.position.x, transform.position.y,distanation.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targ, speed * Time.deltaTime);
        }  
        else
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<CreepHP>().AddHp(-damage);
            Destroy(gameObject);
        }
    }



}
