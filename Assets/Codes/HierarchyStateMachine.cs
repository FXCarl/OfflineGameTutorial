using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface IHierarchyStateMachine : IEventSystemHandler
{
    void SetState(int index);
    void SetNextState();
}

public class HierarchyStateMachine : MonoBehaviour, IHierarchyStateMachine{

    public int CurrentState
    {
        get;
        private set;
    }

	// Use this for initialization
	void Start () {
        SetState(0);
	}

    public void SetState(int index)
    {
        if (transform.childCount < 1) return;
        if (index < 0 || index >= transform.childCount) return;

        Transform trs;
        for (int i = 0; i< transform.childCount; i++)
        {
            trs = transform.GetChild(i);
            trs.gameObject.SetActive(i == index);
        }

        CurrentState = index;
    }

    [ContextMenu("NextState")]
    public void SetNextState()
    {
        SetState(CurrentState + 1);
    }
}
