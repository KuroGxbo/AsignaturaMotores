using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class detectfinal : MonoBehaviour
{
    [SerializeField] private GameObject _Player;
    public Image Key;
    public TextMeshProUGUI Mensaje;

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(_Player.transform.position, this.transform.position);
        var check = Key.fillAmount;
        if (distance < 58 )
        {
            SceneManager.LoadScene(3);
        }
        else {
            Mensaje.SetText("Necesito Una Llave");
        }
    }
}