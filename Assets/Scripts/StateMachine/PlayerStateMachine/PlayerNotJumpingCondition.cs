using UnityEngine;

public class PlayerNotJumpingCondition : Condition
{
    CharacterController _playerController;

    public PlayerNotJumpingCondition(CharacterController playerController)
    {
        _playerController = playerController;
    }

    public override bool Check()
    {
        return !Input.GetKeyDown(KeyCode.Space) && _playerController.isGrounded;
    }
}
