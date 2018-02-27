using UnityEngine;
using UnityEngine.UI;

public class FormInputsDemo : MonoBehaviour
{
    [UnityEngine.Serialization.FormerlySerializedAs("camera")]
    [SerializeField] Camera view;
    [SerializeField] InputField textInput;
    [SerializeField] Text updatedLabel;
    [SerializeField] Transform rotator;
    [SerializeField] CanvasGroup ui;

    float turnsPerSecond;

    public void SetBackgroundColor(int option)
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

    public void UpdateLabelFromInput()
    {
        updatedLabel.text = textInput.text;
    }

    public void SetTurnsPerSecond(float turns)
    {
        turnsPerSecond = turns;
    }

    void Update()
    {
        rotator.Rotate(Vector3.up, turnsPerSecond * Time.deltaTime * 360);
    }

    public void SetUIAlpha(float alpha)
    {
        ui.alpha = alpha;
    }
}
