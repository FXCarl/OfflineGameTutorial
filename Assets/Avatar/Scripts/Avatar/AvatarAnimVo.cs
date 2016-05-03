using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mooji.Avatar
{
    public class AvatarAnimVo : MonoBehaviour
    {
        public int id;
        public Sprite[] s1;
        public Sprite[] s2;
        public Sprite[] s3;
        public Sprite[] s4;
        public Sprite[] s5;



        public void Awake()
        {
            var ss = new SpriteArrSort();
            Array.Sort( s1 , ss );
            Array.Sort( s2 , ss );
            Array.Sort( s3 , ss );
            Array.Sort( s4 , ss );
            Array.Sort( s5 , ss );
        }

    }

    public class SpriteArrSort : IComparer<Sprite>
    {
        public int Compare( Sprite x , Sprite y )
        {
            return int.Parse( x.name ) < int.Parse( y.name ) ? -1 : 1 ;
        }
    }

}
