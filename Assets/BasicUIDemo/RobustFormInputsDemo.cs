using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class RobustFormInputsDemo : MonoBehaviour
{
    [Header("Modified stuff")]
    [SerializeField] Camera view;
    [SerializeField] Text updatedLabel;
    [SerializeField] Transform rotator;
    [SerializeField] Light bulb;
    [SerializeField] Image toFill;

    [Header("Inputs")]
    [SerializeField] InputField textInput;
    [SerializeField] Button textUpdater;
    [SerializeField] Dropdown backgroundSelector;
    [SerializeField] Scrollbar cameraPanner;
    [FormerlySerializedAs("cameraAutoPanner")]
    [SerializeField] Slider imageAutoFiller;
    [SerializeField] Toggle lightSwitch;

    float fillPerSecond;

    void Start()
    {
        textUpdater.onClick.AddListener(UpdateLabelFromInput);
        backgroundSelector.onValueChanged.AddListener(SetBackgroundColor);
        cameraPanner.onValueChanged.AddListener(SetRotation);
        imageAutoFiller.onValueChanged.AddListener(SetFillPerSecond);
        lightSwitch.onValueChanged.AddListener(SetLightEnabled);
    }

    void SetBackgroundColor(int option)
    {
        switch (option)
        {
            case 0:
                view.backgroundColor = Color.magenta;
                break;
            case 1:
                view.backgroundColor = Color.black;
                break;
            case 2:
                view.backgroundColor = Color.yellow;
                break;
        }
    }

    void UpdateLabelFromInput()
    {
        updatedLabel.text = textInput.text;
    }

    void SetFillPerSecond(float fillStep)
    {
        fillPerSecond = fillStep;
    }

    void Update()
    {
        toFill.fillAmount = Mathf.Repeat(toFill.fillAmount + fillPerSecond * Time.deltaTime, 1);
    }

    void SetRotation(float ratio)
    {
        rotator.rotation = Quaternion.AngleAxis(ratio * 360, Vector3.up);
    }

    void SetLightEnabled(bool value)
    {
        bulb.enabled = value;
    }
}
