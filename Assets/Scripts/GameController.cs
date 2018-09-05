using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//实现随机生成障碍物
public class GameController : MonoBehaviour {
    public GameObject hazard;//障碍物对象
    public Vector3 spawnValue;//障碍位置

    public float createStoneRate;//两排石头之间的时间间隔
    private float nextStoneTime;
    private int stoneRowCount;//一排石头的数目。采取一定随机值
    private Vector3 lastStonePosition;//记录上一个石头的位置，保证一排石头不会相碰
    public float stoneSafeDistance;
    public int stoneMinCount;
    public int stoneMaxCount;

    public int stoneMinLimit;
    public int stoneMaxLimit;
    //准备时间
    private float startTime;//开始游戏的时间
    public float waitTime;//玩家的准备时间


    //计分
    private int totalScore;
    public Text scoreText;

    //游戏结束
    public Text gameOverText;
    private bool isGameOver;

    //重新开始游戏、
    public Button ReStartGameBtn;
    private bool isReStartGame;

    //返回按钮
    public Button BackButton;
    //难度
    private int diffLevel;
    public float addDiffRate;
    private float lastAddDiffTime;
	// Use this for initialization
	void Start () {
        gameOverText.text = "";
        isGameOver = false;

        ReStartGameBtn.gameObject.SetActive(false);
        isReStartGame = false;

        BackButton.gameObject.SetActive(false);
        totalScore = 0;
        startTime = Time.time;
        UpdateScore();

        diffLevel = 1;//等级1
	}
	public void AddScore(int score)
    {
        totalScore += score;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score:" + totalScore;
    }
    public void GameOver()
    {
        isGameOver = true;
        gameOverText.text = "GAME OVER!";

        ReStartGameBtn.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(true);
        
    }
	// Update is called once per frame
	void Update () {

        if (Time.time < startTime + waitTime)
        {
            return;
        }
        //增加难度
        if (Time.time > lastAddDiffTime + addDiffRate)
        {

            lastAddDiffTime = Time.time;
            if (stoneMinCount < stoneMinLimit)
            {
                stoneMinCount++;
            }
            if (stoneMaxCount < stoneMaxLimit)
            {
                stoneMaxCount++;
            }
            createStoneRate -= 0.05f;
            if (createStoneRate <= 0.1f)
            {
                createStoneRate = 0.1f;
            }
            diffLevel++;
        }
        if (Time.time >= nextStoneTime)
        {
            nextStoneTime = Time.time + createStoneRate;
            stoneRowCount = Random.Range(stoneMinCount, stoneMaxCount);
            //生成一排障碍物
            for (int i=0; i<stoneRowCount;)
            {
                //障碍生成的位置
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x),
                                                    spawnValue.y, spawnValue.z);
                //障碍的Rotation属性
                Quaternion spawnRotation = Quaternion.identity;
                
                if (Mathf.Abs(lastStonePosition.x - spawnPosition.x) >= stoneSafeDistance)
                {
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    lastStonePosition = spawnPosition;
                    i++;
                }
            }
            lastStonePosition = new Vector3(0, 0, 0);
        }
	}
}
