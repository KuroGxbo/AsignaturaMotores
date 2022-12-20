using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Transform Position;
    public Animator Animation;
    public CharacterController Control;
    public GameObject Obj;
    public ParticleSystem Attack;
    public float Speed = 1f,RotationSpeed, jumpStrength, Gravity = -9.81f, 
        playerSpeed, movement;
    public Vector3 VerticalSpeed, horizontalSpeed;
    public AudioClip coinSound;
    public AudioSource source, sfxSource;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private float inputSpeed;
    public Vector2 turn;
    private Vector2 mousePos;
    private Vector3 screenPos;


    // Start is called before the first frame update
    void Start()
    {
        Obj = GameObject.Find("Player");
        Position = Obj.transform;
        //       Control = GetComponent<CharacterController>();
        Animation = GetComponent<Animator>();
        Attack = Obj.GetComponent<ParticleSystem>();
        inputSpeed = Speed;
        Debug.Log("onCreate:" + SceneManager.GetActiveScene().name);
        scoreText.text = score.ToString();
        switch (SceneManager.GetActiveScene().name)
        {
            case "LevelRunner":
                break;
            case "LevelLaberinth":
                inputSpeed += 30;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        VerticalSpeed += Physics.gravity * Gravity;
        switch (SceneManager.GetActiveScene().name)
        {
            case "LevelRunner":
                level1ForwardMovement();
                break;
            case "LevelLaberinth":
                inputSpeed = 50;
                level2ForwardMovement();
                jump();
                attackCommands();
                rotationMouse();
                break;
            case "Level1":
                level2ForwardMovement();
                jumpL1();
                attackCommands();
                level2Rotation();
                break;
            default:
                level2ForwardMovement();
                jump();
                attackCommands();
                level2Rotation();
                break;
        }
        
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Control.isGrounded)
        {
            VerticalSpeed = jumpStrength * Vector3.up;
            if (Animation.GetFloat("speed") > 5.1f)
            {
                Animation.SetBool("jumpinRun", true);
            }
            else
            {
                Animation.SetBool("jumping", true);
            }
        }
        else if (!Control.isGrounded)
        {
            Animation.SetBool("jumpinRun", false);
            Animation.SetBool("jumping", false);
        }
    }

    void jumpL1()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Control.isGrounded)
        {
            VerticalSpeed = jumpStrength/2 * Vector3.up;
            if (Animation.GetFloat("speed") > 5.1f)
            {
                Animation.SetBool("jumpinRun", true);
            }
            else
            {
                Animation.SetBool("jumping", true);
            }
        }
        else if (!Control.isGrounded)
        {
            Animation.SetBool("jumpinRun", false);
            Animation.SetBool("jumping", false);
        }
    }

    void jumpLRunning(string tagString)
    {
        if (tagString == "isJump")
        {
            Debug.Log("jump");
            if (Input.GetKey(KeyCode.Space) && Control.isGrounded)
            {
                VerticalSpeed = jumpStrength * Vector3.up;
                if (Animation.GetFloat("speed") > 5.1f)
                {
                    Animation.SetBool("jumpinRun", true);
                }
                else
                {
                    Animation.SetBool("jumping", true);
                }
            } else if (!Control.isGrounded)
            {
                Animation.SetBool("jumpinRun", false);
                Animation.SetBool("jumping", false);
            }
        }else
        {
            Animation.SetBool("jumpinRun", false);
            Animation.SetBool("jumping", false);
        }
    }

    void attackCommands()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Animation.GetFloat("speed") < 0.1f)
            {
                Animation.SetTrigger("attack");
            }

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Animation.GetFloat("speed") < 0.1f)
            {
                Animation.SetTrigger("magic");
            }

        }
    }

    void level2Rotation()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, RotationSpeed * horizontalInput, 0));
    }

    void rotationMouse()
    {
        float rotX = Input.GetAxis("Mouse X") * RotationSpeed * Mathf.Deg2Rad;
        transform.RotateAround(Vector3.up, rotX);
    }

    void level2ForwardMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        horizontalSpeed = verticalInput * transform.forward * Speed;

        playerSpeed = verticalInput*5;

        Speed = inputSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = inputSpeed * 2;
            playerSpeed = 10;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {

            Speed = inputSpeed /2;
            playerSpeed = 1;
            Animation.SetBool("crouch", true);
        }
        else
        {
            Animation.SetBool("crouch", false);
        }

        Control.Move((horizontalSpeed + VerticalSpeed) * Time.deltaTime);
        Animation.SetFloat("speed", playerSpeed);
    }

    void level1ForwardMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if( horizontalInput < 0)
        {
            movement = 502.5f;
        } else if (horizontalInput > 0)
        {
            movement = 497.5f;
        } else
        {
            movement = 500f;
        }
        Vector3 target = new Vector3(movement, transform.position.y, transform.position.z);

        Speed = 10;
        horizontalSpeed = transform.forward * Speed;

        playerSpeed = horizontalSpeed.magnitude;

        source.volume = 0.8f;
        Control.Move((VerticalSpeed + horizontalSpeed) * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, target, 50 * Time.deltaTime);
        Animation.SetFloat("speed", playerSpeed);
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "ring":
                Destroy(other.gameObject);
                score += 5;
                sfxSource.PlayOneShot(coinSound);
                scoreText.text = score.ToString();
                break;
            case "ringBlue":
                Destroy(other.gameObject);
                score += 10;
                sfxSource.PlayOneShot(coinSound);
                scoreText.text = score.ToString();
                break;
            case "ringRed":
                Destroy(other.gameObject);
                score += 20;
                sfxSource.PlayOneShot(coinSound);
                scoreText.text = score.ToString();
                break;
            default: break;
        }
        if (other.gameObject.tag == "ring")
        {
            Destroy(other.gameObject);
            score += 5;
            sfxSource.PlayOneShot(coinSound);
            scoreText.text = score.ToString();
        }
        jumpLRunning(other.gameObject.tag);
    }

    public void OnTriggerStay(Collider other)
    {
        jumpLRunning(other.gameObject.tag);
    }
}
