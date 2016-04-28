using UnityEngine;
using System.Collections;

public class FireHandler : MonoBehaviour {

    private Animator m_Animator;
    private int m_FireTriggerID;

	// Use this for initialization
	void OnEnable () {
        m_Animator = GetComponent<Animator>();
        if (m_Animator) m_FireTriggerID = Animator.StringToHash("Fire");
    }

    public virtual void Fire()
    {
        if (m_Animator) m_Animator.SetTrigger(m_FireTriggerID);
    }

    public virtual void DestorySelf()
    {
        Destroy(gameObject, 0.1f);
    }
}
