using UnityEngine;
using System.Collections;

public class UiView : MonoBehaviour {


    public CanvasGroup containerCG;



    void Awake()
    {
        containerCG.alpha = 0;
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
        containerCG.alpha = 0;
        GameObject.Destroy( this.transform.parent );
    }

    public void OnClickedBuilding()
    {

    }
}
