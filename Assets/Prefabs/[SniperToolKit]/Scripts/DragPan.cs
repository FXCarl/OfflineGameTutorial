using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragPan : MonoBehaviour
{

    public Transform target;

    private Vector2 m_AimingStartPos = Vector2.zero;
    public Vector2 m_AimingDragDiff = Vector2.zero;

    public float PercentageMoveByInch = 0.5f;

    public void OnBeginDrag(BaseEventData bed)
    {
        PointerEventData ped = (PointerEventData)bed;
        m_AimingStartPos = ped.position;
    }

    public void OnEndDrag(BaseEventData bed)
    {
        PointerEventData ped = (PointerEventData)bed;
        m_AimingDragDiff = Vector2.zero;
    }

    public void OnDrag(BaseEventData bed)
    {
        PointerEventData ped = (PointerEventData)bed;
        m_AimingDragDiff = Vector2.ClampMagnitude((ped.position - m_AimingStartPos) / Screen.dpi, 1f);
    }

    protected virtual void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 offset = Vector3.zero;
        offset.x = m_AimingDragDiff.x * PercentageMoveByInch * Screen.height * Time.deltaTime;
        offset.y = m_AimingDragDiff.y * PercentageMoveByInch * Screen.height * Time.deltaTime;
        target.localPosition += offset;
    }
}
