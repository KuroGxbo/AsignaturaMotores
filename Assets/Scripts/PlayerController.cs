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
    public GameObject Obj, filaBarriles1, filaBarriles2, filaBarriles3, filaBarriles4, filaBarriles5;
    public Image hearth;
    public ParticleSystem Attack;
    public float SpeedRunning, SpeedRunningVertical, SpeedLab, SpeedLv1, RotationSpeed, jumpStrength, Gravity = -9.81f,
        playerSpeed, health, playerPositionZ;
    public Vector3 VerticalSpeed, horizontalSpeed;
    public AudioClip coinSound;
    public AudioSource source, sfxSource;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public Vector2 turn;
    public PauseMenu menu;
    private float Speed;
    private float movement = 500f;
    private float maxHealth = 100f;
    private bool barrilesCreados = false;
    private bool keyPressed = false;




    // Start is called before the first frame update
    void Start()
    {
        Obj = GameObject.Find("Player");
        Position = Obj.transform;
        //       Control = GetComponent<CharacterController>();
        Animation = GetComponent<Animator>();
        Attack = Obj.GetComponent<ParticleSystem>();
        Debug.Log("onCreate:" + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name != "Level1")
        {
            scoreText.text = score.ToString();
        }
        score = 0;
        if (PlayerPrefs.HasKey("Coins"))
        {
            Debug.Log("Coins Char" + PlayerPrefs.GetInt("Coins"));
            score = PlayerPrefs.GetInt("Coins", 0);
            scoreText.text = score.ToString();
        }
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        VerticalSpeed += Physics.gravity * Gravity;
        if (!menu.EstadoMenu)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "LevelRunner":
                    level1ForwardMovement(SpeedRunning);
                    slideCharacter();
                    jump();
                    BarrelCreation();
                    break;
                case "LevelLaberinth":
                    level2ForwardMovementLab(SpeedLab);
                    jump();
                    attackCommands();
                    rotationMouse();
                    break;
                case "Level1":
                    level2ForwardMovementLab(SpeedLv1);
                    jump();
                    attackCommands();
                    rotationMouse();
                    break;
                default:
                    level2ForwardMovement(SpeedLv1);
                    jump();
                    attackCommands();
                    level2Rotation();
                    break;
            }
        } else
        {
            Animation.SetFloat("speed", 0f);
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

    void level2ForwardMovement(float inputSpeed)
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerSpeed = Mathf.Abs(verticalInput * 5);

        Speed = inputSpeed;
        if (Input.GetKey(KeyCode.LeftShift) && verticalInput != 0)
        {
            Speed = inputSpeed * 2;
            playerSpeed = 10;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {

            Speed = inputSpeed / 2;
            playerSpeed = 1;
            Animation.SetBool("crouch", true);
        }
        else
        {
            Animation.SetBool("crouch", false);
        }
        horizontalSpeed = verticalInput * transform.forward;
        Control.Move((horizontalSpeed + VerticalSpeed) * Speed * Time.deltaTime);
        Animation.SetFloat("speed", playerSpeed);
    }

    void level2ForwardMovementLab(float inputSpeed)
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        playerSpeed = (verticalInput != 0 || horizontalInput != 0) ? 5.0f : 0.0f;

        Speed = inputSpeed;
        if (Input.GetKey(KeyCode.LeftShift) && (verticalInput != 0 || horizontalInput != 0))
        {
            Speed = inputSpeed * 2;
            playerSpeed = 10;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {

            Speed = inputSpeed / 2;
            playerSpeed = 1;
            Animation.SetBool("crouch", true);
        }
        else
        {
            Animation.SetBool("crouch", false);
        }
        horizontalSpeed = verticalInput * transform.forward;
        Vector3 verticalSpeed = horizontalInput * transform.right;
        Control.Move((horizontalSpeed + VerticalSpeed + verticalSpeed) * Speed * Time.deltaTime);
        Animation.SetFloat("speed", playerSpeed);
    }
    void level1ForwardMovement(float inputSpeed)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0 && !keyPressed)
        {
            keyPressed = true;
            movement += 2.5f;
        }
        else if (horizontalInput < 0 && !keyPressed)
        {
            keyPressed = true;
            movement -= 2.5f;
        }

        if (horizontalInput == 0 && keyPressed)
        {
            keyPressed = false;
        }

        if (movement >= 502.5f)
        {
            movement = 502.5f;
        }
        else if (movement <= 497.5f)
        {
            movement = 497.5f;
        }

        Vector3 target = new Vector3(movement, transform.position.y, transform.position.z);

        horizontalSpeed = transform.forward;

        playerSpeed = 12;
        jumpStrength = 2.5f;
        Gravity = 0.02f;

        source.volume = 0.8f;
        Control.Move((VerticalSpeed + horizontalSpeed) * inputSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, target, SpeedRunningVertical * Time.deltaTime);
        Animation.SetFloat("speed", playerSpeed);
    }

    void slideCharacter()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Animation.SetTrigger("slide");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "ring":
                Destroy(other.gameObject);
                score += 5;
                sfxSource.PlayOneShot(coinSound);
                if (SceneManager.GetActiveScene().name != "Level1")
                {
                    scoreText.text = score.ToString();
                }
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    IncreatHealth(5);
                }
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "building")
        {
            Debug.Log("block");
            if (movement <= 497.5f)
            {
                movement = 497.5f;
                Vector3 target = new Vector3(movement, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, target, SpeedRunningVertical * Time.deltaTime);
            }
        }

        else if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("collision");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "building")
        {
            Debug.Log("block");
            if (movement <= 497.5f)
            {
                movement = 497.5f;
                Vector3 target = new Vector3(movement, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, target, SpeedRunningVertical * Time.deltaTime);
            }
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health < 0)
        {
            health = 0;
            Animation.SetBool("died", true);
        }
        hearth.fillAmount = health / maxHealth;
    }

    public void IncreatHealth(float recover)
    {
        health += recover;

        if (health >= 100)
        {
            health = 100;
        }
        hearth.fillAmount = health / maxHealth;
    }

    void BarrelCreation()
    {
        playerPositionZ = GameObject.Find("Player").transform.position.z;

        if (playerPositionZ > 100.00 && barrilesCreados == false)
        {
            Instantiate(filaBarriles1, filaBarriles1.transform.position, Quaternion.identity);
            Instantiate(filaBarriles2, filaBarriles2.transform.position, Quaternion.identity);
            Instantiate(filaBarriles3, filaBarriles3.transform.position, Quaternion.identity);
            Instantiate(filaBarriles4, filaBarriles4.transform.position, Quaternion.identity);
            Instantiate(filaBarriles5, filaBarriles5.transform.position, Quaternion.identity);
            barrilesCreados = true;
        }
    }



}
