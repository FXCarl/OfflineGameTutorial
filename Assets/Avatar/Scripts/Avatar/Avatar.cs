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
        protected GameObject deadAnimGo;

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

        private Image targetMarkerImg;
        void Awake()
        {
            var go = this.transform.parent.FindChild( "TargetMarker" );
            if( go)
            {
                targetMarkerImg = go.transform.GetComponent<Image>();
                targetMarkerImg.transform.gameObject.SetActive( false );
            }
          
        }

        void Start()
        {

            runAnimSpriteMapping = new Dictionary<AnimDir , Sprite[]>();
            idelAnimSpriteMapping = new Dictionary<AnimDir , Sprite[]>();
            m_bStop = true;

            image = GetComponent<Image>();

            currAnimDir = currAnimDir == AnimDir.NONE ? AnimDir.Bottom : currAnimDir;
            currAnimType = AnimType.IDEL;

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

        }

        public void SetCurrAnimType( AnimType at )
        {

            if ( currAnimType != at )
            {
                curFram = 0;
                fTime = 0;
            }

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
            //this.transform.localPosition = Vector3.MoveTowards( this.transform.localPosition , Input.mousePosition , 120 * Time.deltaTime );



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


            RotationAnim();

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

        //public void StopAnim()
        //{
        //    fTime = 0;
        //    curFram = 0;
        //    m_bStop = true;
        //}

        //public void PlayAnim()
        //{
        //    m_bStop = false;
        //}



        private Vector3 prePos;

        public void RotationAnim()
        {

            if ( prePos.Equals( this.transform.localPosition ) )
            {
                SetCurrAnimType( AnimType.IDEL );
                return;
            }

            var vMyX = this.transform.localPosition.x;
            var vMyY = this.transform.localPosition.y;
            var vNpcX = prePos.x;
            var vNpcY = prePos.y;
            vMyX -= vNpcX;
            vMyY -= vNpcY;

            var angle = Math.Atan2( vMyX , vMyY );
            angle = angle*( 180/Math.PI );

            if ( angle<0 )
            {
                //在左边
                if ( angle>-15 )
                {
                    OnMoveTargetChanged( AnimDir.Top );//
                }
                if ( angle<=-15 && angle>=-75 )
                {
                    OnMoveTargetChanged( AnimDir.Left_Top );
                }
                if ( angle< -75 && angle>=-105 )
                {
                    OnMoveTargetChanged( AnimDir.Left );
                }
                if ( angle< -105 && angle>=-165 )
                {
                    OnMoveTargetChanged( AnimDir.Bottom_Left );
                }
                if ( angle<-165 )
                {
                    OnMoveTargetChanged( AnimDir.Bottom );//
                }
            }
            else
            {
                //在右边	
                if ( angle>=75 && angle<=105 )
                {
                    OnMoveTargetChanged( AnimDir.Right );
                }
                if ( angle>=15 && angle<75 )
                {
                    OnMoveTargetChanged( AnimDir.Top_Right);
                }
                if ( angle<15 )
                {
                    OnMoveTargetChanged( AnimDir.Top );//
                }
                if ( angle>105 && angle<165 )
                {
                    OnMoveTargetChanged( AnimDir.Right_Bottom );
                }
                if ( angle>165 )
                {
                    OnMoveTargetChanged( AnimDir.Bottom );
                }
            }

            prePos = this.transform.localPosition;


        }

        public void OnMoveTargetChanged( AnimDir ad )
        {
            SetCurrAnimDic( ad );
            SetCurrAnimType( AnimType.Run );
        }

        public void OnClickedUp()
        {
            var xOffset = Math.Abs( this.transform.position.x - Input.mousePosition.x );
            var yOffset = Math.Abs( this.transform.position.y - Input.mousePosition.y );
            if (xOffset <= 25 && yOffset <= 35) { 
                Debug.Log("Clicked!" + this.gameObject.name);
            }

            //var go = this.transform.FindChild("TargetMarker") ;

            //if ( go && go.gameObject.activeSelf)
            //{
            //    go.GetComponent<TargetMarker>().OnClcked();
            //}
        }

        public void ShowTarget()
        {
            if ( targetMarkerImg )
                targetMarkerImg.gameObject.SetActive( true );
        }
    }

}