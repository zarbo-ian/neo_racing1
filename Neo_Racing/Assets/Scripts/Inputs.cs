using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inputs : MonoBehaviour
{

    void Start (){

    }
    [SerializeField] TextMesh playerScore;

    public string button;
    public string nombre;
    void Update()
    {
        if (Input.GetButtonDown(button))
        {
            Debug.Log(nombre);
        }
        
    }
    
}
