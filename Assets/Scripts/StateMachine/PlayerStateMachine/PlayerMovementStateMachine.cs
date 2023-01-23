using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovementStateMachine : MonoBehaviour
{
    public CharacterController playerController;
    public float speedRunner, speedLab, speedLv1, jumpStrength, health, gravity, speedRunnerVertical, rotationSpeed, simpleJumpSpeed, speedJump;
    public PauseMenu menu;
    public GameObject Obj, filaBarriles1, filaBarriles2, filaBarriles3, filaBarriles4, filaBarriles5;
    public Animator animation;
    public Vector3 VerticalSpeed;
    private float movement = 500f;
    public AudioClip coinSound;
    public AudioSource source, sfxSource;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public Image hearth;
    private float maxHealth = 100f;
    private bool barrilesCreados = false;
    public State currentState;
    public GameObject npc;

    void Start()
    {
        //State
        PlayerWalk walkState = new PlayerWalk(this.gameObject, playerController, animation, VerticalSpeed, gravity, speedRunner, speedRunnerVertical, speedLab, speedLv1, rotationSpeed, menu, jumpStrength, movement);
        PlayerRunning runstate = new PlayerRunning(this.gameObject, playerController, animation, VerticalSpeed, gravity, speedLab, speedLv1, rotationSpeed, menu, jumpStrength);
        PlayerSimpleJump jumpState = new PlayerSimpleJump(playerController, animation, VerticalSpeed, gravity, speedJump, menu, simpleJumpSpeed);
        IdleState idle = new IdleState(this.gameObject, playerController, animation, VerticalSpeed, speedLab, rotationSpeed, gravity, menu);

        currentState = idle;
        //Condition

        PlayerMovementCondition isMoving= new PlayerMovementCondition(menu);
        PlayerRunningCondition isRunning = new PlayerRunningCondition(menu);
        PlayerJump isJumping= new PlayerJump();
        PlayerNotJumpingCondition isNotJumping = new PlayerNotJumpingCondition(playerController);
        PlayerNotRunningAndWalkingCondition isNotExecuteAMovement = new PlayerNotRunningAndWalkingCondition(menu);
        PlayerNotRunningCondition isNotRunning = new PlayerNotRunningCondition();

        //Transition
        Transition idleToMoving = new Transition(walkState, isMoving);
        Transition movingToRunning = new Transition(runstate, isRunning);
        Transition idleToJumping = new Transition(jumpState, isJumping);
        Transition jumpingToIdle = new Transition(idle, isNotJumping);
        Transition runningToWalking = new Transition(walkState, isNotRunning);
        Transition runningToIdle = new Transition(idle, isNotExecuteAMovement);
        Transition walkingToIdle = new Transition(idle, isNotExecuteAMovement);

        //Include transition
        idle.transitions.Add(idleToMoving);
        idle.transitions.Add(idleToJumping);
        walkState.transitions.Add(movingToRunning);
        walkState.transitions.Add(walkingToIdle);
        runstate.transitions.Add(runningToIdle);
        runstate.transitions.Add(runningToWalking);
        jumpState.transitions.Add(jumpingToIdle);
        if(SceneManager.GetActiveScene().name == "LevelRunner") {
            BarrelCreation();
        }
        scoreText.text = score.ToString();
    }
    void Update()
    {
        foreach (Transition transition in currentState.transitions)
        {
            Debug.Log(transition);
            Debug.Log(transition.IsTriggered());
            if (transition.IsTriggered())
            {
                currentState = transition.nextState;
            }
        }
        currentState.DoAction();
        if (SceneManager.GetActiveScene().name == "LevelRunner")
        {
            BarrelCreation();
            if (Vector3.Distance(npc.transform.position, transform.position) < 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (SceneManager.GetActiveScene().name == "LevelLaberinth")
        {
            if (Vector3.Distance(npc.transform.position, transform.position) < 30)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }


    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health < 0)
        {
            health = 0;
            animation.SetBool("died", true);
        }
        hearth.fillAmount = health / maxHealth;
    }

    private void IncreatHealth(float recover)
    {
        health += recover;

        if (health >= 100)
        {
            health = 100;
        }
        hearth.fillAmount = health / maxHealth;
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

        if (collision.gameObject.tag == "Obstacle")
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
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void BarrelCreation()
    {
        float playerPositionZ = GameObject.Find("Player").transform.position.z;

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
