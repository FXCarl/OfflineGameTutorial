using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour {

    public Transform actionTrans;

    public void OnEnable()
    {
        if ( this.transform.parent.gameObject.activeSelf )
            this.StartAction();
        else
            actionTrans.gameObject.SetActive( false );
    }

    private void StartAction()
    {
        actionTrans.gameObject.SetActive( true );
    }

	public void Update()
    {

    }
}
