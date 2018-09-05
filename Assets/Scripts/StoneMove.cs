using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMove : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody>().velocity = speed * Vector3.back;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
