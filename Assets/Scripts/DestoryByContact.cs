using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour {
    public GameObject AsteroidExplosion;//陨石爆炸效果
    public GameObject PlayerExplosion;//飞机爆炸效果
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        //根据碰撞物体的不同设置不同的碰撞效果
        if (other.tag == "Bolt")
        {
            Instantiate(AsteroidExplosion, this.transform.position, this.transform.rotation);
            //加分
            GameObject.Find("GameController").gameObject.SendMessage("AddScore", 10);
        }
        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, this.transform.position, this.transform.rotation);
            //游戏结束
            GameObject.Find("GameController").gameObject.SendMessage("GameOver");
        }
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
