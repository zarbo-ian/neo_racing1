using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Inputs : MonoBehaviour
{
    [SerializeField] TMP_Text playerScore;
    public string button;
    public int numero;
    int score = 0;

    public GameObject jugador;
    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;
    float rotationMultiplier = 5.0f;
    public Vector3 startPos;
    
    void Start (){
        startPos = jugador.transform.position;
    }

    void Update()
    {
        if (Input.GetButtonDown(button))
        {
            IncreaseScore();
            StartShake(.5f, 0.5f);
        }
        playerScore.text = score.ToString();
    }
    
    void IncreaseScore()
    {
        score++;
    }

    private void LateUpdate()
    {
        if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;
            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }
        else
        {
            //float moveX = Mathf.MoveTowards(transform.position.x, startPos.x, shakeFadeTime * 2 * Time.deltaTime);
            //float moveY = Mathf.MoveTowards(transform.position.y, startPos.y, shakeFadeTime * 2 * Time.deltaTime);
            jugador.transform.position = startPos;
        }
        transform.rotation = Quaternion.Euler(0f,0f,shakeRotation * Random.Range(-1f, 1f));
    }

    public void StartShake(float lenght, float power)
    {
        shakeTimeRemaining = lenght;
        shakePower = power;
        shakeFadeTime = power / lenght;

        shakeRotation = power * rotationMultiplier;
    }
}
