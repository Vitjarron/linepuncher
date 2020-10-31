using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {

    public Transform diePos;
    public float speed;

    public bool stop;

	// Use this for initialization
	void Start () {
        stop = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z <= diePos.position.z)
        {
            GameObject.Destroy(gameObject);
        }
        if(!stop) transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, diePos.position.z), speed/Time.deltaTime);
	}
}
