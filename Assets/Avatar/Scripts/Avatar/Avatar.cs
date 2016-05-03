using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Mooji.Avatar
{
    public enum AnimDir
    {
        NONE ,
        Bottom ,
        Bottom_Left ,
        Left ,
        Left_Top ,
        Top ,
        Top_Right ,
        Right ,
        Right_Bottom
    }

    public enum AnimType
    {
        IDEL ,
        Run ,
    }

    public class Avatar : MonoBehaviour
    {
        [SerializeField]
        [Tooltip( "帧速率 , 0 默认情况下就是按照有几列的帧速播放" )]
        protected float fps;

        [SerializeField]
        protected GameObject runAnimGo;

        [SerializeField]
        protected GameObject idelAnimGo;

        [SerializeField]
        protected AnimDir currAnimDir;

        [SerializeField]
        protected AnimType currAnimType;

        private Sprite[] currSpriteArr;
        private Image image;
        private int curFram;
        private float fTime = 0;
        private bool IsISO;

        private Dictionary<AnimDir , Sprite[]> runAnimSpriteMapping;
        private Dictionary<AnimDir , Sprite[]> idelAnimSpriteMapping;
        private bool m_bStop;


        void Start()
        {

            runAnimSpriteMapping = new Dictionary<AnimDir , Sprite[]>();
            idelAnimSpriteMapping = new Dictionary<AnimDir , Sprite[]>();
            m_bStop = true;

            image = GetComponent<Image>();

            currAnimDir = currAnimDir == AnimDir.NONE ? AnimDir.Bottom : currAnimDir;
            currAnimType = AnimType.Run;

            var runAnim = GameObject.Instantiate( runAnimGo ) as GameObject;
            var avatarAnim = runAnim.GetComponent<AvatarAnimVo>();
            runAnimSpriteMapping.Add( AnimDir.Bottom , avatarAnim.s1 );
            runAnimSpriteMapping.Add( AnimDir.Bottom_Left , avatarAnim.s2 );
            runAnimSpriteMapping.Add( AnimDir.Left , avatarAnim.s3 );
            runAnimSpriteMapping.Add( AnimDir.Left_Top , avatarAnim.s4 );
            runAnimSpriteMapping.Add( AnimDir.Top , avatarAnim.s5 );
            runAnimSpriteMapping.Add( AnimDir.Top_Right , avatarAnim.s4 );
            runAnimSpriteMapping.Add( AnimDir.Right , avatarAnim.s3 );
            runAnimSpriteMapping.Add( AnimDir.Right_Bottom , avatarAnim.s2 );


            var idelAnim = GameObject.Instantiate( idelAnimGo ) as GameObject;
            avatarAnim = idelAnim.GetComponent<AvatarAnimVo>();
            idelAnimSpriteMapping.Add( AnimDir.Bottom , avatarAnim.s1 );
            idelAnimSpriteMapping.Add( AnimDir.Bottom_Left , avatarAnim.s2 );
            idelAnimSpriteMapping.Add( AnimDir.Left , avatarAnim.s3 );
            idelAnimSpriteMapping.Add( AnimDir.Left_Top , avatarAnim.s4 );
            idelAnimSpriteMapping.Add( AnimDir.Top , avatarAnim.s5 );
            idelAnimSpriteMapping.Add( AnimDir.Top_Right , avatarAnim.s4 );
            idelAnimSpriteMapping.Add( AnimDir.Right , avatarAnim.s3 );
            idelAnimSpriteMapping.Add( AnimDir.Right_Bottom , avatarAnim.s2 );



            //OnAnimDirChenged();

        }

        private void OnAnimDirChenged()
        {
            //currSpriteArr = runAnimSpriteMapping[ currAnimDir ]; 
        }

        public void SetCurrAnimType( AnimType at )
        {
            this.currAnimType = at;
        }

        public void SetCurrAnimDic( AnimDir ad )
        {
            this.currAnimDir = ad;
        }
       
        void Update()
        {

            //if ( Input.GetMouseButtonUp( 0 ) )
            //{
            //    var v3 = Input.mousePosition;
            //    v3 = new Vector3( ( Screen.width >> 1 ) - v3.x   , ( Screen.height >> 1 ) - v3.y , v3.z );
            //    Debug.Log( v3 + "," + Screen.width + "," + Screen.height);
            //}
            


            if ( AnimDir.Top_Right == currAnimDir || AnimDir.Right == currAnimDir || AnimDir.Right_Bottom == currAnimDir )
            {
                if ( !IsISO )
                {
                    this.transform.Rotate( 0 , 180 , 0 );
                    IsISO = true;
                }
            }
            else
            {
                if ( IsISO )
                    this.transform.Rotate( 0 , -180 , 0 );

                IsISO = false;
            }


            switch( currAnimType )
            {
                case AnimType.Run :
                {
                    currSpriteArr = runAnimSpriteMapping[ currAnimDir ];
                    break ;
                }
                case AnimType.IDEL:
                {
                    currSpriteArr = idelAnimSpriteMapping[ currAnimDir ];
                    break;
                }
            }

            if ( fps == 0 )
                fps = currSpriteArr.Length ;

            image.sprite = currSpriteArr[ curFram ];
            image.SetNativeSize();

            fTime += Time.deltaTime;
            if ( fTime >= 1.0 / fps )
            {
                curFram = ++curFram % currSpriteArr.Length;

                fTime = 0;

                if ( curFram >= currSpriteArr.Length )
                    curFram = 0;
            }
        }

        public void StopAnim()
        {
            fTime = 0;
            curFram = 0;
            m_bStop = true;
        }

        public void PlayAnim()
        {
            m_bStop = false;
        }

        public void OnClickedUp()
        {
            var xOffset = Math.Abs( this.transform.position.x - Input.mousePosition.x );
            var yOffset = Math.Abs( this.transform.position.y - Input.mousePosition.y );
            if ( xOffset <= 25 && yOffset <= 35 )
                Debug.Log("Clicked!");
        }

    }

}