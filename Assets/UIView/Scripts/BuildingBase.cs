using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BuildingBase : MonoBehaviour {

    public HierarchyStateMachine hsm;
    public Animator animator;
    public Image loadingImg;
    public string trigger ;

    private bool isCreateBuilding;
    private bool isRuning;



	public void OnAnimEnd()
    {
        hsm.SetNextState();
    }

    public void OnEnable()
    {
        if( this.transform.parent.gameObject.activeSelf )
        {
            animator.SetTrigger( trigger );
        }
    }


    //public void BuildButtonClicked()
    //{


    //    if ( isRuning )
    //        return;

    //    isRuning = true;

    //    if ( !isCreateBuilding )
    //    {
    //        animator.SetTrigger( "Building" );
    //        isCreateBuilding = true;
    //    }
    //    else
    //    {
    //        animator.SetTrigger( "Npc" );
    //    }
    //}

}
