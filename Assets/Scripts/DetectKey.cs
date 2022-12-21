using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectKey : MonoBehaviour
{
    [SerializeField] private GameObject _Player;

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(_Player.transform.position, this.transform.position);
        if (distance < 5)
        {
            PlayerPrefs.SetFloat("XKeyLab", 823.5f);
            PlayerPrefs.SetFloat("YKeyLab", 0.39999f);
            PlayerPrefs.SetFloat("ZKeyLab", 870.3f);
            PlayerPrefs.SetInt("KeyForest", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);


        }
    }
}
