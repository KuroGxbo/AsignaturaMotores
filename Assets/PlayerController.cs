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
    private float playerSpeed;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    public bool Run=false;
    private bool Walk = false;

    // Start is called before the first frame update
    void Start()
    {
        Obj = GameObject.Find("Player");
        Position = Obj.transform;
 //       Control = GetComponent<CharacterController>();
        Animation = GetComponent<Animator>();
        Attack = Obj.GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && Control.isGrounded)
        {
            VerticalSpeed = jumpStrength * Vector3.up;
            if (Animation.GetFloat("speed") > 5.1f)
            {
                Animation.SetBool("jumpinRun", true);
            } else
            {
                Animation.SetBool("jumping", true);
            }
        } else if (Control.isGrounded)
        {
            Animation.SetBool("jumpinRun", false);
            Animation.SetBool("jumping", false);
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(Animation.GetFloat("speed") < 0.1f)
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

        VerticalSpeed += Physics.gravity * Gravity;

        Vector3 horizontalSpeed = verticalInput * transform.forward * Speed;

        transform.Rotate(new Vector3(0,RotationSpeed * horizontalInput, 0));
        Control.Move((horizontalSpeed + VerticalSpeed) * Time.deltaTime);

        playerSpeed = horizontalSpeed.magnitude;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed *= 3;
        }
        Animation.SetFloat("speed",playerSpeed);
    }

}
