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
    public float Gravity = -9.81f;
    public float Angle;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity = 0.5f;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    public bool Run=false;
    private bool Walk = false;

    // Start is called before the first frame update
    void Start()
    {
        Obj = GameObject.Find("Player");
        Position = Obj.transform;
        Control = GetComponent<CharacterController>();
        Animation = GetComponent<Animator>();
        Attack = Obj.GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * Speed * Time.deltaTime, Space.World);

        transform.rotation = Quaternion.Slerp(Position.rotation, Position.rotation, Time.deltaTime);

        //Magic Attack
        if (Input.GetKeyDown(KeyCode.Q))
        {

            Animation.SetTrigger("Magic");
            Attack.Play();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Animation.SetTrigger("Idle");
            Attack.Stop();
        }
        //Walk Front
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Walk= true;
            if (!Run)
            {
                Animation.SetTrigger("Walk");
            }
        }else
        {
            Run = false;
            Walk= false;
            Animation.SetTrigger("Idle");
        }
        
        //Run       
        if (Walk)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Run = true;
                Animation.SetTrigger("Run");
            }else
            {
                Run = false;
                Animation.SetTrigger("Walk");
            }
        }
        
        //Punch
        if (Input.GetKeyDown(KeyCode.E))
        {
            Animation.SetTrigger("Punch");
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Animation.SetTrigger("Idle");
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Animation.SetTrigger("Jump");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Animation.SetTrigger("Idle");
        }



    }
}
