using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNotRunningCondition : Condition
{
    public override bool Check()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "LevelLaberinth":
                return !Input.GetKey(KeyCode.LeftShift) && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0);
            case "Level1":
                return !Input.GetKey(KeyCode.LeftShift) && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0);
            default: return false;
        }
    }
}
