using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BuildingBase : MonoBehaviour {

    public Animator animator;
    public Image loadingImg;


    private bool isCreateBuilding;
    private bool isRuning;

	public void OnAnimEnd()
    {
        isRuning = false;
        Debug.Log( "isRuning = " + isRuning );
        //loadingImg.fillAmount = 0;
    }

    public void BuildButtonClicked()
    {


        if ( isRuning )
            return;

        isRuning = true;

        if ( !isCreateBuilding )
        {
            animator.SetTrigger( "Building" );
            isCreateBuilding = true;
        }
        else
        {
            animator.SetTrigger( "Npc" );
        }
    }

}
