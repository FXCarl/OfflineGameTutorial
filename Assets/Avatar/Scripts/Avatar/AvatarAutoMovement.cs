using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

namespace Mooji.Avatar
{


    public class AvatarAutoMovement : MonoBehaviour
    {

        [SerializeField]
        protected Transform pathInfoRoot;

        [SerializeField]
        protected float moveSpeed;

        private Transform[] pathArr;

        private Transform start;

        private RectTransform avatarTrans;

        private int autoPathIndex = 1;

        private Avatar avatarComponent;



        void Awake()
        {
            pathArr = pathInfoRoot.GetComponentsInChildren<RectTransform>();

            if ( pathArr.Length > 0 )
            {
                start = pathArr[ autoPathIndex ];
                this.avatarTrans = GetComponent<RectTransform>();
                this.avatarTrans.localPosition = start.localPosition;
                autoPathIndex += 1;
            }

            avatarComponent = GetComponent<Avatar>();

        }
        void Start()
        {

        }


        void Update()
        {

            if ( autoPathIndex >= pathArr.Length )
            {
                OnAutoMoveComplete();
                return;
            }

            float dis = Vector3.Distance( this.avatarTrans.localPosition , pathArr[ autoPathIndex ].localPosition );

            if ( dis <= 0.01f )
            {
                autoPathIndex += 1;
            }
            else
            {
                RotationAnim();
                this.avatarTrans.localPosition = Vector3.MoveTowards( this.avatarTrans.localPosition , pathArr[ autoPathIndex ].localPosition , moveSpeed * Time.deltaTime );
            }

        }


        protected void OnAutoMoveComplete()
        {
            avatarComponent.SetCurrAnimType( AnimType.IDEL );
        }


        public void RotationAnim()
        {

            var vMyX = avatarTrans.localPosition.x;
            var vMyY = avatarTrans.localPosition.y;
            var vNpcX = pathArr[ autoPathIndex ].localPosition.x;
            var vNpcY = pathArr[ autoPathIndex ].localPosition.y;
            vMyX -= vNpcX;
            vMyY -= vNpcY;

            var angle = Math.Atan2( vMyX , vMyY );
            angle = angle*( 180/Math.PI );

            if ( angle<0 )
            {
                //在左边
                if ( angle>-15 )
                {
                    OnMoveTargetChanged( AnimDir.Bottom );
                }
                if ( angle<=-15 && angle>=-75 )
                {
                    OnMoveTargetChanged( AnimDir.Right_Bottom );
                }
                if ( angle< -75 && angle>=-105 )
                {
                    OnMoveTargetChanged( AnimDir.Right );
                }
                if ( angle< -105 && angle>=-165 )
                {
                    OnMoveTargetChanged( AnimDir.Top_Right );
                }
                if ( angle<-165 )
                {
                    OnMoveTargetChanged( AnimDir.Top );
                }
            }
            else
            {
                //在右边	
                if ( angle>=75 && angle<=105 )
                {
                    OnMoveTargetChanged( AnimDir.Left );
                }
                if ( angle>=15 && angle<75 )
                {
                    OnMoveTargetChanged( AnimDir.Bottom_Left );
                }
                if ( angle<15 )
                {
                    OnMoveTargetChanged( AnimDir.Bottom );
                }
                if ( angle>105 && angle<165 )
                {
                    OnMoveTargetChanged( AnimDir.Left_Top );
                }
                if ( angle>165 )
                {
                    OnMoveTargetChanged( AnimDir.Top );
                }
            }
        }


        public void OnMoveTargetChanged( AnimDir ad )
        {
            avatarComponent.SetCurrAnimDic( ad );
            avatarComponent.SetCurrAnimType( AnimType.Run );
        }

        public void StopAnim()
        {
        }

        public void PlayAnim()
        {
        }


    }
}