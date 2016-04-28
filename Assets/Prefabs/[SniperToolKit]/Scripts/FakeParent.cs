using UnityEngine;
using System.Collections;

public class FakeParent : MonoBehaviour {
	
	public Transform parent;

    private Vector3 m_PositionDiff;

    void OnEnable()
    {
        m_PositionDiff = transform.position - parent.position;
    }

	void LateUpdate ()
    {
	    this.transform.position = parent.position + m_PositionDiff;
	}
}
