using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody rBody;
    public Animator anim;
    public Animator vault;
    public GameManager gameManager;
    MenuController menuController;
    public float forwardSpeed;
    public float jumpForce;
    public int desiredLane = 1;
    public float distance = 4;

    public TextMeshProUGUI score;

    public TextMeshProUGUI coins;
    float coinsValue = 0;

    public TextMeshProUGUI highscore;
    public TextMeshProUGUI finalScore;

    bool isOnLeft;
    bool isOnRight;

    bool isWon;

    bool canMove = true;

    int endCount = 0;

    public float lerpTime;

    public bool inAir;

    public InputActionProperty horizontal;
    public InputActionProperty jump;
    public InputActionProperty reset;

    // Start is called before the first frame update
    void Start()
    {
        //coins.text = coinsValue.ToString();
        //menuController = FindObjectOfType<MenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        //ResetButton();
        //CoinUpdate();
        //Jump();
        MoveCharacter();
    }

    private void FixedUpdate()
    {
        rBody.velocity = transform.forward * (forwardSpeed * Time.deltaTime);
        //Debug.Log(transform.eulerAngles.y);
        if (transform.eulerAngles.y == 0)
        {
            if ((desiredLane == 0 || desiredLane == 1) && isOnLeft)
            {
                transform.position += Vector3.left * distance;
                isOnLeft = false;
            }
            else if ((desiredLane == 2 || desiredLane == 1) && isOnRight)
            {
                transform.position += Vector3.right * distance;
                isOnRight = false;
            }
        }
        else if (transform.eulerAngles.y == 270)
        {
            if ((desiredLane == 0 || desiredLane == 1) && isOnLeft)
            {
                transform.position += Vector3.forward * (-distance);
                isOnLeft = false;
            }
            else if ((desiredLane == 2 || desiredLane == 1) && isOnRight)
            {
                transform.position += Vector3.forward * (distance);
                isOnRight = false;
            }
        }

    }

    private void Jump()
    {
        bool isJumping = (jump.action.IsPressed() || Input.GetButton("Jump"));

        if (isJumping && !inAir)
        {
            rBody.AddForce(Vector3.up * (jumpForce * Time.deltaTime), ForceMode.VelocityChange);
        }
    }

    private void ResetButton()
    {
        if (reset.action.IsPressed())
        {
            SceneManager.LoadScene(0);
        }
    }

    private void MoveCharacter()
    {
        Vector2 moveInput = horizontal.action.ReadValue<Vector2>();


        if (moveInput.x == 0)
            canMove = true;

        if (moveInput.x > 0 && canMove || (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0))
        {
            if (desiredLane != 2)
                isOnRight = true;

            desiredLane++;

            if (desiredLane == 3)
                desiredLane = 2;

            canMove = false;
        }
        else if (moveInput.x < 0 && canMove || (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0))
        {
            if (desiredLane != 0)
                isOnLeft = true;

            desiredLane--;

            if (desiredLane == -1)
                desiredLane = 0;

            canMove = false;
        }
    }

    private void CoinUpdate()
    {
        if (coinsValue < 0)
            coinsValue = 0;

        score.text = ((int)(coinsValue + gameManager.timer)).ToString();
    }

    IEnumerator VaultOpenEnd()
    {
        vault.SetTrigger("Open");

        yield return new WaitForSeconds(0.5f);


        endCount = 1;

    } 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Ground")
        {
            inAir = false;
        }
        
        if (collision.transform.gameObject.tag == "Ground" && collision.transform.gameObject.name.Contains("stairs"))
        {
            Debug.Log("Hello");
            rBody.AddForce(Vector3.up * (1000 * Time.deltaTime), ForceMode.VelocityChange);
        }

        if (collision.transform.gameObject.tag == "Obstacle")
        {
            gameManager.stumble.Play();
            coinsValue = coinsValue - 50;
            coins.text = coinsValue.ToString();

            if(collision.transform.gameObject.name.Contains("Table"))
            {
                rBody.AddForce(Vector3.up * 230, ForceMode.VelocityChange);
            }
            else
            {
                if (desiredLane == 0)
                {
                    desiredLane = 1;
                    transform.position += Vector3.forward * (distance);
                }

                else if (desiredLane == 1)
                {
                    desiredLane = 0;
                    transform.position += Vector3.forward * (-distance);
                }

                else if (desiredLane == 2)
                {
                    desiredLane = 1;
                    transform.position += Vector3.forward * (-distance);
                }

            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Ground")
        {
            inAir = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TurnRight")
        {
            transform.Rotate(0, 90, 0, Space.Self);
            if (desiredLane == 0)
            {
                transform.position += Vector3.forward * (distance);
            }
            else if (desiredLane == 2)
            {
                transform.position += Vector3.forward * (-distance);
            }
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "TurnLeft")
        {
            transform.Rotate(0, -90, 0, Space.Self);
            if (desiredLane == 0)
            {
                transform.position += Vector3.left * distance;
            }
            else if (desiredLane == 2)
            {
                transform.position += Vector3.right * distance;
            }
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Coin")
        {
            gameManager.coinPick.Play();
            other.transform.gameObject.SetActive(false);
            coinsValue = coinsValue + 100;
            coins.text = coinsValue.ToString();
        }

        else if (other.gameObject.tag == "End")
        {
            if(endCount == 0)
               StartCoroutine(VaultOpenEnd());
            else
            {
                menuController.finalScore = score.text;
                //menuController.Level1();
            }
        }
    }
}
