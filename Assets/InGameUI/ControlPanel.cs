using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject[] lights;
    [SerializeField] GameObject display;

    public void ToggleDoor()
    {
        door.SetActive(!door.activeSelf);
    }

    public void ToggleLights()
    {
        foreach (var light in lights)
        {
            light.SetActive(!light.activeSelf);
        }
    }

    public void ShutDown()
    {
        display.SetActive(false);
    }
}
