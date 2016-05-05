using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mooji.Avatar;

public class TargetManager : MonoBehaviour
{

    public List<GameObject> targets;

    private GameObject currentTarget;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnDisable()
    {

    }

    public void OnEnable()
    {
        SelectTarget();
    }

    private GameObject GetOne()
    {
        if (null != targets && targets.Count > 0)
        {
            return targets[0];
        }
        return null;
    }

    public void SelectTarget()
    {
        GameObject go = GetOne();
        if (null != go)
        {
            this.currentTarget = go;
            Mooji.Avatar.Avatar ava = go.GetComponentInChildren<Mooji.Avatar.Avatar>();
            if (null != ava)
            {
                ava.ShowTarget();
            }
        }
    }

    public void RemoveOne(GameObject go)
    {
        if (null != targets && targets.Count > 0 && null!=currentTarget && go==currentTarget)
        {
            GameObject.Destroy(currentTarget);
            targets.Remove(currentTarget);
        }
        SelectTarget();
    }
}
