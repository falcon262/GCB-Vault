using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public float forwardSpeed;
    public float distance = 3.5f;
    public float jumpForce;
    public int desiredLane = 1;
    int endCount = 0;

    public bool canTurnRight;
    public bool canTurnLeft;
    public bool canJump;
    public bool canMove;

    public Rigidbody rbody;
    public GameManager gameManager;
    public Animator vault;

    public TextMeshProUGUI score;

    public TextMeshProUGUI coins;
    float coinsValue = 0;

    public TextMeshProUGUI highscore;
    public MenuController menuController;


    public InputActionProperty horizontal;
    public InputActionProperty jump;
    public InputActionProperty reset;


    // Start is called before the first frame update
    void Start()
    {
        coins.text = ((int)coinsValue).ToString();
        score.text = ((int)(coinsValue + gameManager.timer)).ToString();
        highscore.text = score.text;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.gameStart)
        {
            score.text = ((int)(coinsValue + gameManager.timer)).ToString();
            highscore.text = score.text;
            Locomotion();
            RotateRight();
            RotateLeft();
        }
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void Locomotion()
    {
        Vector2 moveInput = horizontal.action.ReadValue<Vector2>();

        if (moveInput.x == 0)
            canMove = true;

        this.transform.Translate(new Vector3(0,0,forwardSpeed * Time.deltaTime));
        if (((moveInput.x > 0 && canMove) || Input.GetKeyDown(KeyCode.D)) && desiredLane <= 1)
        {
            if(transform.eulerAngles.y < 0.5f)
            {
                desiredLane++;
                transform.position += Vector3.right * distance;
            }
            else if (transform.eulerAngles.y >= 90)
            {
                desiredLane++;
                transform.position += Vector3.back * distance;
            }
            canMove= false;
        }
        else if (((moveInput.x < 0 && canMove) || Input.GetKeyDown(KeyCode.A)) && desiredLane >= 1)
        {
            if (transform.eulerAngles.y < 0.5f)
            {
                desiredLane--;
                transform.position += Vector3.left * distance;
            }
            else if (transform.eulerAngles.y >= 90)
            {
                desiredLane--;
                transform.position += Vector3.forward * distance;
            }
            canMove = false;
        }

    }

    private void Jump()
    {
        bool isJumping = (jump.action.IsPressed() || Input.GetButton("Jump"));

        if (isJumping && canJump)
        {
            rbody.AddForce(Vector3.up * (jumpForce), ForceMode.Force);
        }
    }

    private void RotateRight()
    {
        if(transform.eulerAngles.y < 90 && canTurnRight)
        {
            this.transform.Rotate(0, 2.5f, 0);
        }
        else if(transform.eulerAngles.y >= 90 && canTurnRight)
        {
            canTurnRight = false;
            forwardSpeed = 15f;
            canJump= true; //TODO bug fix 
        }
    }
    
    private void RotateLeft()
    {
        if(transform.eulerAngles.y > 0.5f && canTurnLeft)
        {
            this.transform.Rotate(0, -2.5f, 0);
        }
        else if(transform.eulerAngles.y < 0.5f && canTurnLeft)
        {
            canTurnLeft = false;
            forwardSpeed = 15f;
            canJump = true; //TODO bug fix 
        }
    }

    IEnumerator VaultOpenEnd()
    {
        vault.SetTrigger("Open");

        yield return new WaitForSeconds(0.5f);


        endCount = 1;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.tag == "Ground")
        {
            canJump = true;
        }

        if (collision.transform.gameObject.tag == "Obstacle")
        {
            gameManager.stumble.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "TurnRight")
        {
            canTurnRight = true;
            forwardSpeed = 0;
            other.transform.gameObject.SetActive(false);
        }        
        
        if (other.transform.gameObject.tag == "TurnLeft")
        {
            canTurnLeft = true;
            forwardSpeed = 0;
            other.transform.gameObject.SetActive(false);
        }

        if(other.transform.gameObject.tag == "JetPack")
        {
            var explosionClone = Instantiate(gameManager.explosion, other.transform.position, other.transform.rotation);
            gameManager.takeOff.Play();
            Destroy(explosionClone, 7);
            StartCoroutine(Fly());
            other.transform.gameObject.SetActive(false);
        }

        if (other.transform.gameObject.tag == "Coin")
        {
            gameManager.coinPick.Play();
            other.transform.gameObject.SetActive(false);
            coinsValue++;
            coins.text = ((int)coinsValue).ToString();
        }

        if (other.gameObject.tag == "End")
        {
            if (endCount == 0)
                StartCoroutine(VaultOpenEnd());
            else
            {
                gameManager.gameStart = false;
                menuController.finalScore = score.text;
                menuController.Level1();
            }
        }
    }

    private IEnumerator Fly()
    {
        transform.position += Vector3.up * distance;
        rbody.useGravity = false;
        yield return new WaitForSeconds(7);
        rbody.useGravity = true;
    }

}
