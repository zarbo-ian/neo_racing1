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
        display.text = time.ToString("f0");
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            
        }
        
    }

}
