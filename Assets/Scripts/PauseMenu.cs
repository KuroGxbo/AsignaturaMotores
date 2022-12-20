using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _Player;
    [SerializeField] private GameObject _MainMenu;
    [SerializeField] private GameObject _QuitGame;
    [SerializeField] private GameObject _Panel;
    [SerializeField] private GameObject _Fondo;
    [SerializeField] private GameObject _CoinScore;
    [SerializeField] private GameObject _MainIcon;
    [SerializeField] private GameObject _MainText;
    private string ActualScene;
    private float XPos;
    private float YPos;
    private float ZPos;
    private int coins;
    private bool key;
    public bool EstadoMenu;

    // Start is called before the first frame update
    void Start()
    {
        _Fondo.SetActive(false);
        _Panel.SetActive(false);
        _MainText.SetActive(false);
        _MainIcon.SetActive(false);
        EstadoMenu = false;
        if (PlayerPrefs.GetFloat("X")!=0) {
            _Player.transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));

            PlayerPrefs.GetInt("Coins");
            PlayerPrefs.GetInt("Key");
        }
        if (PlayerPrefs.GetFloat("TpX")!=0) {
            _Player.transform.position = new Vector3(PlayerPrefs.GetFloat("TpX"), PlayerPrefs.GetFloat("TpY"), PlayerPrefs.GetFloat("TpZ"));
            key = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            EstadoMenu = !EstadoMenu;
            if (EstadoMenu) {
                _Fondo.SetActive(true);
                _Panel.SetActive(true);
                _MainText.SetActive(true);
                _MainIcon.SetActive(true);
                _CoinScore.SetActive(false);
                Pause();
                
            }
            else {
                _Fondo.SetActive(false);
                _Panel.SetActive(false);
                _CoinScore.SetActive(true);
                _MainText.SetActive(false);
                _MainIcon.SetActive(false);
                Resume();
            }
        }
    }

    public void SaveProgress() {
        ActualScene=SceneManager.GetActiveScene().name;
        XPos =_Player.transform.position.x;
        YPos = _Player.transform.position.y;
        ZPos = _Player.transform.position.z;
        coins = 0;
        var keystatus = Convert.ToInt32(key);
        PlayerPrefs.SetString("Escena",ActualScene);
        PlayerPrefs.SetFloat("X",XPos);
        PlayerPrefs.SetFloat("Y",YPos);
        PlayerPrefs.SetFloat("Z",ZPos);
        PlayerPrefs.SetInt("Coins",coins);
        PlayerPrefs.SetInt("Key",keystatus);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("Escena"));
        Debug.Log(PlayerPrefs.GetFloat("X"));
        Debug.Log(PlayerPrefs.GetFloat("Y"));
        Debug.Log(PlayerPrefs.GetFloat("Z"));
        Debug.Log(PlayerPrefs.GetInt("Coins"));
        Debug.Log(PlayerPrefs.GetInt("Key"));

    }

    public void MainMenu()
    {
        Debug.Log("EntryMain");
        Resume();
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Boom");
        Application.Quit();
    }

    public void Pause() {
        Time.timeScale = 0f;
    }
    public void Resume() {
        Time.timeScale = 1f;
    }
}
