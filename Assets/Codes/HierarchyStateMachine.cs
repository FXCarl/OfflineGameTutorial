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
        SetState(0);    //  设置Index为0
	}

    public void SetState(int index)
    {
        //  如果Index的大小大于transform的子物体的个数 并且 父对象不为空。     则发送一个事件（自己的父对象go，data ； lamda表达式 下一个状态）
        if (index >= transform.childCount && transform.parent != null)
        {
            ExecuteEvents.ExecuteHierarchy<IHierarchyStateMachine>(transform.parent.gameObject, null, (machine, data) => { machine.SetNextState(); Debug.Log(machine); });
        }

        //  如果transform 没有子对象物体 或者 index小于0 或者 index超出transform的子物体个数 return。
        if (transform.childCount < 1 || index < 0 || index >= transform.childCount)
        {
            return;
        }

        Transform trs;
        for (int i = 0; i< transform.childCount; i++)
        {
            trs = transform.GetChild(i);
            trs.gameObject.SetActive(i == index);
        }

        CurrentState = index;
        //Debug.Log(CurrentState);
    }

    public void Test() {
        Debug.Log("UI_Event");
    }
    [ContextMenu("NextState")]
    public void SetNextState()
    {
        SetState(CurrentState + 1);
    }

    //delegate int del(int i);
    
    //void calldel(GameObject go, Object data, del somefunction)
    //{
    //    if (go.GetComponent<Transform>() != null)
    //    {
    //        go.transform.x = somefunction(1);
    //        return;
    //    }
    //    else
    //    {
    //        calldel(go.transform.parent.gameObject, null, somefunction);
    //    }
    //}

    //void Someone()
    //{
    //    calldel(gameObject, null, x => { return x * x; });
    //}
}
