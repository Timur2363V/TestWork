using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Transform handle;
    [SerializeField]
    private float moveRadiusHandle;

    public Vector3 Position => (handle.transform.position - transform.position).normalized;

    private static Joystick instance;
    public static Joystick Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<Joystick>();
            }
            return instance;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 inputPosition = eventData.position;
        Vector3 offset = inputPosition - transform.position;
        offset = new Vector3(offset.x, offset.y, 0);
        handle.position = transform.position + Vector3.ClampMagnitude(offset, moveRadiusHandle);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        handle.localPosition = Vector3.zero;
    }
}
