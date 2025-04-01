using UnityEngine;
using DG.Tweening;

public class ElementShake : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static ElementShake instance;
    private void Awake() => instance = this;

    private void OnShake(float duration, float strenght)
    {
        transform.DOShakePosition(duration, strenght);
    }

}
