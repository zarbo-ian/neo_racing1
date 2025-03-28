using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Inputs : MonoBehaviour
{
    [SerializeField] TMP_Text playerScore;
    public string button;
    public string nombre;
    int score = 0;
    void Start (){
        
    }

    void Update()
    {
        if (Input.GetButtonDown(button))
        {
            IncreaseScore();
        }
        playerScore.text = score.ToString();
    }
    
    void IncreaseScore()
    {
        score++;
    }
}
