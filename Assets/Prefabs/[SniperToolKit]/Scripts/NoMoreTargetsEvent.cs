using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class NoMoreTargetsEvent : MonoBehaviour {

    void OnEnable()
    {
        StartCoroutine(CheckTargets());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator CheckTargets()
    {
        while (enabled && Application.isPlaying)
        {
            bool noMore = true;
            Transform trs;
            for (int i = 0; i < transform.childCount; i++)
            {
                trs = transform.GetChild(i);
                if (trs.childCount > 0) noMore = false;
            }
            if (noMore) ExecuteEvents.ExecuteHierarchy<IHierarchyStateMachine>(transform.parent.gameObject, null, (machine, data) => { machine.SetNextState();});
            yield return new WaitForSeconds(1f);
        }
    }
}
