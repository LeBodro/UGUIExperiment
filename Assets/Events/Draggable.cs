using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 delta;

    public void OnBeginDrag(PointerEventData data)
    {
        delta.Set(data.delta.x, data.delta.y, 0);
        GetComponent<Rigidbody>().AddForce(delta * 100);
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
