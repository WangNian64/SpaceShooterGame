using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;//范围
}
public class PlayerController : MonoBehaviour {
    public float speed;//飞机速度
    public float tilt;//飞船倾斜幅度
    public Boundary boundary;//定义边界

    private float nextFire;//下一发子弹发射的时间
    public float fireRate;//子弹的发射频率
    public GameObject shot;//子弹对象
    public Transform showSpawn;//子弹发射点
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            //每发射一个子弹就更新下一发子弹的时间（根据发射频率）
            nextFire = Time.time + fireRate;
            Instantiate(shot, showSpawn.position, showSpawn.rotation);
            //调用播放资源并播放
            this.GetComponent<AudioSource>().Play();
        }
    }

    private void FixedUpdate()
    {
        //得到虚拟轴的偏移量，偏移是相对于上一帧计算的
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //给飞机施加一个恒定的速度
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        this.GetComponent<Rigidbody>().velocity = movement * speed;

        //添加飞机倾斜效果
        this.GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f,
            this.GetComponent<Rigidbody>().velocity.x * -tilt);

        //mathf.clamp限制位置
        this.GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(this.GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                0.0f, Mathf.Clamp(this.GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
    }
}
