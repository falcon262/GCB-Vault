using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    //public Button Play;

    public string finalScore;
    public bool oculusPause;


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MusicManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        GamePause();
    }

    private void GamePause()
    {
        if (oculusPause)
        {
            Time.timeScale = 0;
        }
        else { Time.timeScale = 1; }
    }

    private void OnApplicationFocus(bool focus)
    {
        oculusPause = !focus;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Level1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }




}
