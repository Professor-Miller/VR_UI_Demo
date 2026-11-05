using UnityEngine;
using UnityEngine.UI;

public class FloatingUI_Demo : MonoBehaviour
{
    [SerializeField] private LightController lightController;
    [SerializeField] private Button[] colorButtons;
    [SerializeField] private Toggle lightToggle;

    private void OnEnable()
    {
        if (lightController == null)
            return;

        lightController.OnLightChanged += UpdateUI;
        UpdateUI();
    }

    private void OnDisable()
    {
        if (lightController != null)
            lightController.OnLightChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        lightToggle.SetIsOnWithoutNotify(lightController.IsLightOn);

        for (int i = 0; i < colorButtons.Length; i++)
        {
            if (colorButtons[i] != null)
                colorButtons[i].interactable =
                    i != lightController.ColorIndex;
        }
    }
}
