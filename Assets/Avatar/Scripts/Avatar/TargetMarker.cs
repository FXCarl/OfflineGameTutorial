using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TargetMarker : MonoBehaviour
{

    public void OnClcked()
    {
        GameObject go = GameObject.Find( "TargetManager" );
        if ( null != go )
        {
            TargetManager tm = go.GetComponent<TargetManager>();
            tm.RemoveOne();
        }


    }

}
