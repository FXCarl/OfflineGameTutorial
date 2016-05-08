using UnityEngine;
using System.Collections;

public class Sniper : MonoBehaviour {

    public Transform snipertarget ;
    public Transform bgTarget;
    public Transform actionTarget;

    public HierarchyStateMachine hsm ;
	// Use this for initialization
	void Start () {
        snipertarget.gameObject.SetActive( true );
        bgTarget.gameObject.SetActive( false );
        actionTarget.gameObject.SetActive( false );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    internal void complete()
    {
        snipertarget.gameObject.SetActive( false );
        bgTarget.gameObject.SetActive( true );
        hsm.SetNextState();
       
    }
}
