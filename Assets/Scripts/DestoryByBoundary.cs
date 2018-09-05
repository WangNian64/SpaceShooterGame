using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByBoundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //内置函数，其他物体退出该碰撞器时做什么
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
