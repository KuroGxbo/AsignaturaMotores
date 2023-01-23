using UnityEngine;

public class PlayerJump : Condition
{

    public override bool Check()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
