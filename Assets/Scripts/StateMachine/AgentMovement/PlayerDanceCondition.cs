using UnityEngine;

public class PlayerDanceCondition : Condition
{
    float time = 0;
    public override bool Check()
    {
        time += Time.deltaTime;
        while(time <= 5)
        {
            time += Time.deltaTime;
        }
        return true;
    }

}
