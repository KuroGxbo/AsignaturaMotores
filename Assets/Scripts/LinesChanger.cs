using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LinesChanger : MonoBehaviour
{
    public List<string> Frases;
    public TMP_Text Texto;
    private float ChangeTime = 5.0f;
    private float OriginalTime = 0.0f;
    public System.Random Random;
    public String Frase;

    public LinesChanger() {
        Frases = new List<string>();
        Random = new System.Random();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Frases.Add(new string("¡Hecho en Night City!"));
        Frases.Add(new string("BB-8"));
        Frases.Add(new string("Fus Roh Da"));
        Frases.Add(new string("Ryza Waifu"));

        Texto = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        OriginalTime += Time.deltaTime;

        if (OriginalTime > ChangeTime)
        {
            ChangeText();

            // Remove the recorded 2 seconds.
            OriginalTime = 0.0f;
        }



    }

    void ChangeText() {
        var Arr = Frases.ToArray();
        Frase = Arr[Random.Next(0, Arr.Length - 1)];
        Texto.SetText(Frase);
    }

}
