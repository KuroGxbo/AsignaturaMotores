using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRunning : State
{
    GameObject _player;
    CharacterController _playerController;
    Animator _animation;
    Vector3 _VerticalSpeed;
    float _jumpStrenght, _SpeedLab, _SpeedLv1, _RotationSpeed, _gravity;
    PauseMenu _menu;

    public PlayerRunning(GameObject player, CharacterController playerController, Animator animation, Vector3 verticalSpeed, float gravity, float speedLab, float speedLv1, float rotationSpeed, PauseMenu menu, float jumpStrength)
    {
        _player = player;
        _playerController = playerController;
        _animation = animation;
        _VerticalSpeed = verticalSpeed;
        _SpeedLab = speedLab;
        _SpeedLv1 = speedLv1;
        _RotationSpeed = rotationSpeed;
        _gravity = gravity;
        _menu = menu;
        _jumpStrenght = jumpStrength;
    }

    public override void DoAction()
    {
        if (!_menu.EstadoMenu)
        {
            _VerticalSpeed += Physics.gravity * _gravity;
            switch (SceneManager.GetActiveScene().name)
            {
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

    private void freeMovement(float inputSpeed)
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 horizontalSpeed = verticalInput * _player.transform.forward;
        Vector3 verticalSpeed = horizontalInput * _player.transform.right;

        _playerController.Move((horizontalSpeed + verticalSpeed + _VerticalSpeed) * (2 * inputSpeed) * Time.deltaTime);
        _animation.SetFloat("speed", 10);
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
            _animation.SetBool("jumpinRun", true);
        }
        else if (!_playerController.isGrounded)
        {
            _animation.SetBool("jumpinRun", false);
        }
    }
}
