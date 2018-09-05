using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		//给子弹一个速度
        this.GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
