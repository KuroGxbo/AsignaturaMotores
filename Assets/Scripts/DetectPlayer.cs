using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _Player;

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(_Player.transform.position,this.transform.position);
        if (distance<35) {

            SceneManager.LoadScene(2);

        }
    }
}
