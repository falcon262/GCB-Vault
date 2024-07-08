using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class WinScript : MonoBehaviour
{
    MenuController menuController;
    public TextMeshProUGUI score;
    public TextMeshProUGUI Highscore;

    // Start is called before the first frame update
    void Start()
    {
        menuController = FindObjectOfType<MenuController>();
        score.text = menuController.finalScore;
        Highscore.text = menuController.finalScore;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
