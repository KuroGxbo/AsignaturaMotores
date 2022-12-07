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
        if (Input.GetKeyDown(KeyCode.W))
        {
            Run = true;
           

        }
        if (Run) {
            Animation.SetTrigger("Walk");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Animation.SetTrigger("Idle");
        }
        //Walk Back
        if (Input.GetKeyDown(KeyCode.S))
        {
            
            Animation.SetTrigger("Walk");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Animation.SetTrigger("Idle");
        }
        //Walk Front
        if (Input.GetKeyDown(KeyCode.A))
        {
            
            Animation.SetTrigger("Walk");

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Animation.SetTrigger("Walk");
        }
        //Walk Back
        if (Input.GetKeyDown(KeyCode.D))
        {
            
            Animation.SetTrigger("Walk");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Animation.SetTrigger("Idle");
        }
        //Run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Run = true;
            //Animation.SetTrigger("Run");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Run = false;
            //Animation.SetTrigger("Run");
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
