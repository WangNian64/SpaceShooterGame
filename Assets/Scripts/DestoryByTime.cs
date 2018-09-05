using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//销毁爆炸效果物体
public class DestoryByTime : MonoBehaviour
{
    private float createTime;//爆炸的生成时间
    public float destoryRate;//收回爆炸的间隔时间
                             // Use this for initialization
    void Start()
    {
        createTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > createTime + destoryRate)
        {
            Destroy(this.gameObject);
        }
    }
}
