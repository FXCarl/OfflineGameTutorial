using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioSourceConfig : MonoBehaviour
{

    public AudioClip[] ActDialogAudio;
    public AudioClip[] BackGroundMusic;
    public AudioClip[] ShotSound;
    public AudioClip[] BurningBottle;
    public AudioClip[] ZombieDeath;
    public AudioClip[] SustainBuring;

    public Dictionary<string, AudioClip> audioclipMapping = new Dictionary<string,AudioClip>();

	// Use this for initialization
	void Start () {

        for( int i = 0; i < ActDialogAudio.Length; i++ )
        {
            //Debug.Log( ActDialogAudio[ i ].name );
            audioclipMapping.Add( ActDialogAudio[i].name , ActDialogAudio[i] );
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
