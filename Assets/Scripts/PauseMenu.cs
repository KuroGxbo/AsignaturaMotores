using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public Image Key;
    public TextMeshProUGUI Objetivo;
    public TextMeshProUGUI Mensaje;
    private string ActualScene;
    private float XLab;
    private float YLab;
    private float ZLab;

    private float XFore;
    private float YFore;
    private float ZFore;

    private float XRun;
    private float YRun;
    private float ZRun;

    private float XKeyLab;
    private float YKeyLab;
    private float ZKeyLab;

    private bool KeyForest;

    private int CoinsRun;
    private int CoinsForest;
    private int CoinsLab;
    public bool EstadoMenu;

    // Start is called before the first frame update
    void Start()
    {
        _Fondo.SetActive(false);
        _Panel.SetActive(false);
        _MainText.SetActive(false);
        _MainIcon.SetActive(false);
        Key.fillAmount = 0;
        _Fondo.SetActive(false);
        _Panel.SetActive(false);
        _MainText.SetActive(false);
        _MainIcon.SetActive(false);
        EstadoMenu = false;
        switch (SceneManager.loadedSceneCount)
        {
            case 1:
                if (PlayerPrefs.HasKey("XKeyLab")) {
                    _Player.transform.position.Set(PlayerPrefs.GetFloat("XKeyLab"), PlayerPrefs.GetFloat("YKeyLab"), PlayerPrefs.GetFloat("ZKeyLab"));
                    CoinsLab = PlayerPrefs.GetInt("CoinsLab");
                    KeyForest = Convert.ToBoolean(PlayerPrefs.GetInt("KeyForest"));
                    if (KeyForest)
                    {
                        Key.fillAmount = 1;
                        Objetivo.SetText(String.Empty);
                        Mensaje.SetText(String.Empty);
                    }
                }
                if (PlayerPrefs.HasKey("XLab"))
                {
                    _Player.transform.position.Set(PlayerPrefs.GetFloat("XLab"), PlayerPrefs.GetFloat("YLab"), PlayerPrefs.GetFloat("ZLab"));
                    CoinsLab = PlayerPrefs.GetInt("CoinsLab");
                    KeyForest = Convert.ToBoolean(PlayerPrefs.GetInt("KeyForest"));
                    if (KeyForest) {
                        Key.fillAmount = 1;
                        Objetivo.SetText(String.Empty);
                        Mensaje.SetText(String.Empty);
                    }
                }
                break;
            case 2:
                if (PlayerPrefs.HasKey("XFore"))
                {
                    _Player.transform.position.Set(PlayerPrefs.GetFloat("XKeyLab"), PlayerPrefs.GetFloat("YFore"), PlayerPrefs.GetFloat("ZFore"));
                    CoinsForest = PlayerPrefs.GetInt("CoinsForest");
                }
                break;
            case 3:
                if (PlayerPrefs.HasKey("XRun"))
                {
                    _Player.transform.position.Set(PlayerPrefs.GetFloat("XRun"), PlayerPrefs.GetFloat("YRun"), PlayerPrefs.GetFloat("ZRun"));
                    CoinsRun = PlayerPrefs.GetInt("CoinsRun");
                }
                break;
            default:
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EstadoMenu = !EstadoMenu;
            if (EstadoMenu)
            {
                _Fondo.SetActive(true);
                _Panel.SetActive(true);
                _MainText.SetActive(true);
                _MainIcon.SetActive(true);
                _CoinScore.SetActive(false);
                Pause();

            }
            else
            {
                _Fondo.SetActive(false);
                _Panel.SetActive(false);
                _CoinScore.SetActive(true);
                _MainText.SetActive(false);
                _MainIcon.SetActive(false);
                Resume();
            }
        }
    }

    public void SaveProgress()
    {
        ActualScene = SceneManager.GetActiveScene().name;
        
        switch (SceneManager.loadedSceneCount)
        {
            case 1:
                PlayerPrefs.DeleteAll();
                PlayerPrefs.SetString("Escena", ActualScene);
                PlayerPrefs.SetFloat("XLab", _Player.transform.position.x);
                PlayerPrefs.SetFloat("YLab", _Player.transform.position.y);
                PlayerPrefs.SetFloat("ZLab", _Player.transform.position.z);
                PlayerPrefs.SetInt("CoinsLab", CoinsLab);
                PlayerPrefs.SetInt("KeyForest", Convert.ToInt32(KeyForest));
                PlayerPrefs.Save();
                Debug.Log(PlayerPrefs.GetString("Escena"));
                Debug.Log(PlayerPrefs.GetFloat("XLab"));
                Debug.Log(PlayerPrefs.GetFloat("YLab"));
                Debug.Log(PlayerPrefs.GetFloat("ZLab"));
                Debug.Log(PlayerPrefs.GetInt("CoinsLab"));
                Debug.Log(PlayerPrefs.GetInt("KeyForest"));
                break;
            case 2:
                PlayerPrefs.DeleteAll();
                PlayerPrefs.SetString("Escena", ActualScene);
                PlayerPrefs.SetFloat("XFore", _Player.transform.position.x);
                PlayerPrefs.SetFloat("YFore", _Player.transform.position.y);
                PlayerPrefs.SetFloat("ZFore", _Player.transform.position.z);
                PlayerPrefs.SetInt("CoinsForest", CoinsForest);
                PlayerPrefs.SetInt("KeyForest", Convert.ToInt32(KeyForest));
                PlayerPrefs.Save();
                Debug.Log(PlayerPrefs.GetString("Escena"));
                Debug.Log(PlayerPrefs.GetFloat("XFore"));
                Debug.Log(PlayerPrefs.GetFloat("YFore"));
                Debug.Log(PlayerPrefs.GetFloat("ZFore"));
                Debug.Log(PlayerPrefs.GetInt("CoinsForest"));
                Debug.Log(PlayerPrefs.GetInt("KeyForest"));
                break;
            case 3:
                PlayerPrefs.DeleteAll();
                PlayerPrefs.SetString("Escena", ActualScene);
                PlayerPrefs.SetFloat("XRun", _Player.transform.position.x);
                PlayerPrefs.SetFloat("YRun", _Player.transform.position.y);
                PlayerPrefs.SetFloat("ZRun", _Player.transform.position.z);
                PlayerPrefs.SetInt("CoinsRun", CoinsRun);
                PlayerPrefs.Save();
                Debug.Log(PlayerPrefs.GetString("Escena"));
                Debug.Log(PlayerPrefs.GetFloat("XRun"));
                Debug.Log(PlayerPrefs.GetFloat("YRun"));
                Debug.Log(PlayerPrefs.GetFloat("ZRun"));
                Debug.Log(PlayerPrefs.GetInt("CoinsRun"));
                break;
            default:
                break;
        }

        

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

    public void Pause()
    {
        Time.timeScale = 0f;

    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
