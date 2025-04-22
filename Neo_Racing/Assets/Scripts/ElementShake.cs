using UnityEngine;
using DG.Tweening;

public class ElementShake : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static ElementShake Instance;
    public int nombre;
    private void Awake() => Instance = this;

    private void OnShake(float duration, float strenght)
    {
        transform.DOShakePosition(duration, strenght);
        transform.DOShakePosition(duration, strenght);
    }

    public static void Shake(float duration, float strenght) => Instance.OnShake(duration, strenght);
}
