using System;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light pointLight;

    private readonly Color[] colors =
    {
        Color.white,
        Color.blue,
        Color.red
    };

    public int ColorIndex { get; private set; } = 0;
    public bool IsLightOn => pointLight.enabled;

    public event Action OnLightChanged;

    private void Awake()
    {
        pointLight.enabled = true;
        pointLight.color = colors[ColorIndex];
    }

    public void ToggleLight()
    {
        pointLight.enabled = !pointLight.enabled;
        OnLightChanged?.Invoke();
    }

    public void ChangeLightColor(int index)
    {
        if (index < 0 || index >= colors.Length)
            return;

        ColorIndex = index;
        pointLight.color = colors[index];

        OnLightChanged?.Invoke();
    }
}
