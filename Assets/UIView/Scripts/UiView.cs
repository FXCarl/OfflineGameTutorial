using UnityEngine;
using System.Collections;

public class UiView : MonoBehaviour {


    public CanvasGroup containerCG;

    public HierarchyStateMachine hStateMachine ;

    public Transform topUI;

    public Transform topUICopy;

    void Awake()
    {
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        if ( containerCG.alpha == 1 )
            return;

	    if( this.transform.parent)
        {
            if( this.transform.parent.gameObject.activeSelf )
            {
                Show();
            }
        }
	}


    public void Show()
    {
        containerCG.alpha = 1;
    }

    public void Close()
    {
        if ( topUICopy )
            topUICopy.gameObject.SetActive( true );

        hStateMachine.SetNextState();
    }

    public void OnCreateNameComplete()
    {
        topUI.gameObject.SetActive( true );
        this.transform.gameObject.SetActive( false );
        Invoke( "Close" , 1.5f );
    }


    public void OnClickedBuilding()
    {

    }
}
