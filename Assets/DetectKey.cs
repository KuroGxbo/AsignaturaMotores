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
            PlayerPrefs.SetFloat("TpX", 408.18f);
            PlayerPrefs.SetFloat("TpY", 17.1f);
            PlayerPrefs.SetFloat("TpZ", 296.2f);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
            

        }
    }
}
