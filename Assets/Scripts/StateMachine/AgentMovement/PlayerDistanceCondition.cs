using UnityEngine;

public class PlayerDistanceCondition : Condition
{
    public GameObject _player;
    public GameObject _npc;
    public float _minDistance;

    public PlayerDistanceCondition(GameObject player, GameObject npc, float minDistance)
    {
        _player = player;
        _npc = npc;
        _minDistance = minDistance;
    }

    public override bool Check()
    {
        float distance = Vector3.Distance(_player.transform.position, _npc.transform.position);

        return distance <= _minDistance;
    }
}

