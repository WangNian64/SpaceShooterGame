using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameClick : MonoBehaviour {
    public string gameSceneName;
    public void OnStartGame()
    {
        //切换场景
        SceneManager.LoadScene(gameSceneName);
    }
}
