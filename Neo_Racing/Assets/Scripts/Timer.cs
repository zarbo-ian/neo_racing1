using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Timeline.Actions;
using Unity.VisualScripting;

public class Timer: MonoBehaviour
{
    public float time;

    public TMP_Text display;

    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;
    float rotationMultiplier = 5.0f;
    public Vector3 startPos;
    public GameObject button;

    bool invoked = false;

    private void Start()
    {
        //startPos.x = button.transform.position.x;
        //startPos.y = button.transform.position.y;
        startPos = transform.position;
    }
    private void Update()
    {
        display.text = time.ToString("f0");
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        if (time <= 9.5f && invoked == false)
        {
            display.color = Color.red;
            InvokeRepeating("ShakeTimerWrapper", 0.1f, 1.0f); //no me permite llamar al método directamente así que necestio el warper
            invoked = true;
        }
        if (time <= 0f)
        {
            CancelInvoke("ShakeTimerWrapper");
        }
    }
    private void LateUpdate()
    {
        //Antes de que alguien pregunte: no, no puedo hacer esto un script propio que cada elemento llame cuando hay que sacudirlo
        if (shakeTimeRemaining > 0)
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
            transform.position = startPos;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));
    }

    void ShakeTimerWrapper()
    {
        ShakeTimer(0.5f, 0.5f);
    }


    public void ShakeTimer(float lenght, float power)
    {
        shakeTimeRemaining = lenght;
        shakePower = power;
        shakeFadeTime = power / lenght;

        shakeRotation = power * rotationMultiplier;
    }
}
