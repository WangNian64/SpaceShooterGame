using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackClick : MonoBehaviour {
    public void OnBackButton()
    {
        SceneManager.LoadScene("GameWelcome");
    }
}
