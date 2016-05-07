using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour {

    public static int CURR_ACTION_NUM = 0;
    public Transform actionTrans;

    public void OnEnable()
    {
       var actionGo = GameObject.Find("Action" + CURR_ACTION_NUM);
       if ( actionGo != null )
           actionGo.SetActive( false );

        if ( this.transform.parent.gameObject.activeSelf )
        {
            this.StartAction();
        }
    }

    private void StartAction()
    {
        if ( actionTrans )
        {
            actionTrans.gameObject.SetActive( true );
            CURR_ACTION_NUM += 1;
        }
    }

	public void Update()
    {

    }
}
