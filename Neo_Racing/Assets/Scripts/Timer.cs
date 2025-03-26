using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Timer: MonoBehaviour
{
    public float time;

    public TMP_Text display;

    private void Update()
    {
        time -= Time.deltaTime;
        display.text = time.ToString("f0");
    }

}
