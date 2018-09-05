using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float tumble;//陨石翻滚的幅度
	// Use this for initialization
	void Start () {
        //给陨石一个随机角速度
        this.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
