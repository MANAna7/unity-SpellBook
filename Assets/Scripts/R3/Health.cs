using UniRx;
using UnityEngine;

public class Health : MonoBehaviour
{
    public ReactiveProperty<int> HealthValue = new ReactiveProperty<int>();
    private void Start() => HealthValue.Value = 100;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            HealthValue.Value -= 10;
    }
}