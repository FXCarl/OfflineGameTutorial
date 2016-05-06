using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mooji.Avatar;

public class TargetManager : MonoBehaviour
{

    public List<GameObject> targets;

    public List<GameObject> bloodTargets; 

    public TargetMarker tm;
    public HierarchyStateMachine hsm;
    public float invokeTime;
    private GameObject currentTarget;


    private bool isStart;
    private int bloodIndex;

    void Start()
    {
        isStart = false;
        tm.transform.position = new Vector3(-1000,0,0);
        bloodIndex = 0;
    }

    void Update()
    {
        try
        {
            if ( currentTarget != null )
                tm.transform.position = currentTarget.GetComponentInChildren<Mooji.Avatar.Avatar>().transform.position;
        }
        catch ( System.Exception )
        {
        }
        

        if ( isStart )
            return;

        if( this.transform.parent.gameObject.activeSelf)
        {
            isStart = true;

            Invoke( "SelectTarget" , invokeTime );
            //SelectTarget();
        }
    }

    public void OnDisable()
    {

    }

    public void OnEnable()
    {
        
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
        else
        {
            currentTarget = null;
            tm.gameObject.SetActive( false );
            hsm.SetNextState();
        }
    }

    public void RemoveOne()
    {
        if ( null != targets && targets.Count > 0 && null!=currentTarget ) //go==currentTarget
        {
            //GameObject.Destroy(currentTarget);
            
            var bloodEffVo = bloodTargets[ bloodIndex ].GetComponent<BloodEffVo>();
            bloodEffVo.ShowEff( currentTarget.GetComponentInChildren<Mooji.Avatar.Avatar>() );
            bloodIndex += 1;


            currentTarget.SetActive( false );
            targets.Remove( currentTarget );
        }
        SelectTarget();
    }
}
