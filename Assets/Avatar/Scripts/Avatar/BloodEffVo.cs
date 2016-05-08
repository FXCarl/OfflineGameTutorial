using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
public class BloodEffVo : MonoBehaviour
{
    public string filterStr;
    public bool loop;
    public Sprite[] s1;

    private float fTime;
    private int curFram;
    private Image image;

    private bool start;
    public void Awake()
    {
        image = GetComponent<Image>();
        var ss = new SpriteArrSort();
        Array.Sort( s1 , ss );
        start = false;
        this.transform.position = new Vector3( -1000 , 0 , 0 );
    }

    public void Update()
    {
        if ( !start )
            return;

        image.sprite = s1[ curFram ];
        image.SetNativeSize();

        fTime += Time.deltaTime;
        if ( fTime >= 1.0 / s1.Length )
        {
            curFram = ++curFram % s1.Length;

            fTime = 0;

            if ( curFram >= s1.Length - 1 )
            {
                start = false;
                curFram = 0;
                this.gameObject.SetActive( false );
                GameObject.Destroy( this.gameObject );
            }
        }
    }

    public void ShowEff( Mooji.Avatar.Avatar avatar )
    {
        this.transform.position = avatar.transform.position;
        start = true;
    }
}

public class SpriteArrSort : IComparer<Sprite>
{
    public int Compare( Sprite x , Sprite y )
    {
        if( x.name.IndexOf("blood_") == 0)
        {
            var xName = x.name.Replace( "blood_" , "" );
            var yName = y.name.Replace( "blood_" , "" );
            return int.Parse( xName ) < int.Parse( yName ) ? -1 : 1;
        }
        else
        {
            var xName = x.name.Replace( "fire_" , "" );
            var yName = y.name.Replace( "fire_" , "" );
            return int.Parse( xName ) < int.Parse( yName ) ? -1 : 1;
        }
    }
}




