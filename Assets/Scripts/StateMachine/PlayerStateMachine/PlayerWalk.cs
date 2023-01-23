using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWalk : State
{
    GameObject _player;
    CharacterController _playerController;
    Animator _animation;
    Vector3 _VerticalSpeed;
    float _jumpStrenght,_SpeedRunning, _SpeedRunningVerical, _SpeedLab, _SpeedLv1, _RotationSpeed,_gravity, _movement;
    PauseMenu _menu;
    private bool keyPressed = false;

    public PlayerWalk(GameObject player, CharacterController playerController, Animator animation,Vector3 verticalSpeed, float gravity, float speedRunning, float speedRunningVerical, float speedLab, float speedLv1, float rotationSpeed, PauseMenu menu, float jumpStrength, float movement)
    {
        _player = player;
        _playerController = playerController;
        _animation = animation;
        _VerticalSpeed = verticalSpeed;
        _SpeedRunning = speedRunning;
        _SpeedRunningVerical = speedRunningVerical;
        _SpeedLab = speedLab;
        _SpeedLv1 = speedLv1;
        _RotationSpeed = rotationSpeed;
        _gravity = gravity;
        _menu = menu;
        _jumpStrenght = jumpStrength;
        _movement= movement;
    }

    public override void DoAction()
    {
        if (!_menu.EstadoMenu) {
            _VerticalSpeed += Physics.gravity * _gravity;
            switch (SceneManager.GetActiveScene().name)
            {
                case "LevelRunner":
                    runnerMovement(_SpeedRunning);
                    jump();
                    break;
                case "LevelLaberinth":
                    freeMovement(_SpeedLab);
                    rotationMouse();
                    jump();
                    break;
                case "Level1":
                    freeMovement(_SpeedLv1);
                    rotationMouse();
                    jump();
                    break;
            }
        }
        
    }

    private void runnerMovement(float inputSpeed)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0 && !keyPressed)
        {
            keyPressed = true;
            _movement += 2.5f;
        }
        else if (horizontalInput < 0 && !keyPressed)
        {
            keyPressed = true;
            _movement -= 2.5f;
        }

        if (horizontalInput == 0 && keyPressed)
        {
            keyPressed = false;
        }

        Vector3 horizontalSpeed = _player.transform.forward;
        Vector3 target = new Vector3(_movement, _player.transform.position.y, _player.transform.position.z);
        _playerController.Move((_VerticalSpeed + horizontalSpeed) * inputSpeed * Time.deltaTime);
        _player.transform.position = Vector3.Lerp(_player.transform.position, target, _SpeedRunningVerical * Time.deltaTime);
        _animation.SetFloat("speed", 10);
    }

    private void freeMovement(float inputSpeed)
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 horizontalSpeed = verticalInput * _player.transform.forward;
        Vector3 verticalSpeed = horizontalInput * _player.transform.right;

        _playerController.Move((horizontalSpeed + verticalSpeed + _VerticalSpeed) * inputSpeed * Time.deltaTime);
        _animation.SetFloat("speed", 5);
    }

    private void rotationMouse()
    {
        float rotX = Input.GetAxis("Mouse X") * _RotationSpeed * Mathf.Deg2Rad;
        _player.transform.RotateAround(Vector3.up, rotX);
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _playerController.isGrounded)
        {
            _VerticalSpeed = _jumpStrenght * Vector3.up;
            if (_animation.GetFloat("speed") > 5.1f)
            {
                _animation.SetBool("jumpinRun", true);
            }
            else
            {
                _animation.SetBool("jumping", true);
            }
        }
        else if (!_playerController.isGrounded)
        {
            _animation.SetBool("jumping", false);
            _animation.SetBool("jumpinRun", false);
        }
    }
}
