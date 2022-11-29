using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Position;
    public Animator Animation;
    public CharacterController Control;
    public GameObject Obj;
    public ParticleSystem Attack;
    public float Speed = 80f;
    public float Gravity = -9.81f;
    public float Angle;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity = 0.5f;

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
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Horizontal, Vertical, 0).normalized;

        //Movement
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + Position.eulerAngles.y;

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            Control.SimpleMove(moveDir.normalized * Speed * Time.deltaTime);
        }

        //Magic Attack
        if (Input.GetKeyDown(KeyCode.Q)) {

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
            Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 90, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, Angle, 0);
            Animation.SetTrigger("Walk");
           
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Animation.SetTrigger("Idle");
        }
        //Walk Back
        if (Input.GetKeyDown(KeyCode.S))
        {
            Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 90, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, Angle, 0);
            Animation.SetTrigger("Walk");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Animation.SetTrigger("Idle");
        }
        //Run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed = 100f;
            Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 90, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, Angle, 0);
            Animation.SetTrigger("Run");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed = 80f;
            Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 90, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, Angle, 0);
            Animation.SetTrigger("Run");
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
