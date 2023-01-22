using UnityEngine;

public class FarAwayPlayerCondition : Condition
{
    GameObject _player;
    GameObject _npc;
    float _minDistance;

    public FarAwayPlayerCondition(GameObject player, GameObject npc, float minDistance)
    {
        _player = player;
        _npc = npc;
        _minDistance = minDistance;
    }

    public override bool Check()
    {
        return Vector3.Distance(_npc.transform.position, _player.transform.position) > _minDistance;
    }
}
