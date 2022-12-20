using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
   
    public void LoadLevel() {
        SceneManager.LoadScene(PlayerPrefs.GetString("Escena"));
        Debug.Log(PlayerPrefs.GetString("Escena"));

    }
}
