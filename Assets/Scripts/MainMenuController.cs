using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Animator animator;

    public GameManager gameManager;
    public Character character;

    public GameObject MenuCameraRig;
    public GameObject MainCameraRig;

    public bool startClick;
    public bool canStart;

    public TextMeshProUGUI finalHighScore;

    // Start is called before the first frame update
    void Start()
    {
        canStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canStart)
        {
            StartCoroutine(StartRoutine());
        }

    }

    private IEnumerator StartRoutine()
    {
        animator.SetBool("RunStart", true);
        yield return new WaitForSeconds(1.3f);
        gameManager.gameStart = true;
        StartCoroutine(gameManager.StartTimer());
        canStart= false;
        animator.transform.gameObject.SetActive(false);
        MenuCameraRig.gameObject.SetActive(false);
        MainCameraRig.gameObject.SetActive(true);
    }

    public void StartClick()
    {
        StartCoroutine(StartRoutine());
    }
}
