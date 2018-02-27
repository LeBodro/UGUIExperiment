using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 delta;
    Vector3 torque;
    Rigidbody ownBody;

    void Start()
    {
        ownBody = GetComponent<Rigidbody>();
    }

    public void OnBeginDrag(PointerEventData data)
    {
        delta.Set(data.delta.x, data.delta.y, 0);
        ownBody.AddForce(delta * 100);
    }

    public void OnDrag(PointerEventData eventData)
    {
        torque.Set(eventData.delta.y, eventData.delta.x, 0);
        ownBody.AddRelativeTorque(torque);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ownBody.position = Vector3.zero;
    }
}
