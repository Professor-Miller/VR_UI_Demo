using UnityEngine;
using UnityEngine.InputSystem;

public class WristUI_Demo : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LightController lightController;
    [SerializeField] private InputActionReference toggleMenuInput;
    [SerializeField] private GameObject wristUI;

    [Header("Buttons")]
    [SerializeField] private GameObject[] colorButtons;
    [SerializeField] private GameObject[] lightToggles;

    private void OnEnable()
    {
        if (lightController != null)
        {
            lightController.OnLightChanged += UpdateUI;
            UpdateUI();
        }

        if (toggleMenuInput != null)
            toggleMenuInput.action.performed += ToggleWristMenu;
    }

    private void Start()
    {
        wristUI.SetActive(false);
    }

    private void OnDisable()
    {
        if (lightController != null)
            lightController.OnLightChanged -= UpdateUI;

        if (toggleMenuInput != null)
            toggleMenuInput.action.performed -= ToggleWristMenu;
    }

    private void UpdateUI()
    {
        UpdateButtons(colorButtons, lightController.ColorIndex);

        // 0 = Turn On, 1 = Turn Off
        int selectedIndex = lightController.IsLightOn ? 1 : 0;
        UpdateButtons(lightToggles, selectedIndex);
    }

    private void UpdateButtons(GameObject[] buttons, int selectedIndex)
    {
        if (buttons == null)
            return;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] != null)
                buttons[i].SetActive(i != selectedIndex);
        }
    }

    private void ToggleWristMenu(InputAction.CallbackContext context)
    {
        wristUI.SetActive(!wristUI.activeSelf);
    }
}
