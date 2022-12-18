using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform Position;
    public Animator Animation;
    public CharacterController Control;
    public GameObject Obj;
    public ParticleSystem Attack;
    public Image Img;
    public float Speed = 1f;
    public float RotationSpeed,jumpStrength;
    public Vector3 VerticalSpeed;
    public float Gravity = -9.81f;
    public float Angle;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity = 0.5f;
    private float playerSpeed, inputSpeed;
    public bool Run=false;
    private Vector3 horizontalSpeed;
    public AudioClip coinSound;
    public AudioSource source, sfxSource;

    // Start is called before the first frame update
    void Start()
    {
        Obj = GameObject.Find("Player");
        Position = Obj.transform;
 //       Control = GetComponent<CharacterController>();
        Animation = GetComponent<Animator>();
        Attack = Obj.GetComponent<ParticleSystem>();
        inputSpeed = Speed;

    }

    // Update is called once per frame
    void Update()
    {
        level1ForwardMovement();
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
        else if (Control.isGrounded)
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
        VerticalSpeed += Physics.gravity * Gravity;
        transform.Rotate(new Vector3(0, RotationSpeed * horizontalInput, 0));
    }

    void level2ForwardMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        horizontalSpeed = verticalInput * transform.forward * Speed;

        playerSpeed = horizontalSpeed.magnitude;

        Speed = inputSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 10;
            playerSpeed *= 3;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {

            Speed = 1f;
            playerSpeed /= 3;
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
        float speedVolumeController = 0.4f;
        horizontalSpeed = transform.forward * Speed;
        
        Vector3 rightMovement = horizontalInput * transform.right * Speed;

        playerSpeed = horizontalSpeed.magnitude;

        Speed = inputSpeed;
       
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 10;
            playerSpeed *= 3;
            speedVolumeController = 0.8f; ;
        }
        source.volume = Mathf.Abs(horizontalInput / 5) + speedVolumeController;
        Control.Move((horizontalSpeed + VerticalSpeed + rightMovement) * Time.deltaTime);
        Animation.SetFloat("speed", playerSpeed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ring")
        {
            Destroy(other.gameObject);
            sfxSource.PlayOneShot(coinSound);
        }
    }
}
