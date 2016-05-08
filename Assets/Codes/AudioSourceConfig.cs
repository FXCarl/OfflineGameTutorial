using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioSourceConfig : MonoBehaviour
{
    public GameObject shotSound;
    public GameObject burningBottleSound;
    public GameObject zombileDeathSound;

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

    public void PlayShotSound() {
        GameObject playShotSound =  Instantiate( shotSound, Vector3.zero,Quaternion.identity) as GameObject;
        playShotSound.transform.parent = transform;
        int num = Random.Range(0,ShotSound.Length);
        //Debug.Log(num);
        playShotSound.GetComponent<AudioSource>().clip = ShotSound[ num ];
        playShotSound.GetComponent<AudioSource>().Play();
    }

    public void PlayBurningBottle() {
        GameObject playBurningBottle =  Instantiate( burningBottleSound , Vector3.zero , Quaternion.identity ) as GameObject;
        playBurningBottle.transform.parent = transform;
        int num = Random.Range( 0 , BurningBottle.Length );
        //Debug.Log(num);
        playBurningBottle.GetComponent<AudioSource>().clip = BurningBottle[ num ];
        playBurningBottle.GetComponent<AudioSource>().Play();
    }

    public void PlayZombileDeath() {
        GameObject playZombieDeath =  Instantiate( zombileDeathSound , Vector3.zero , Quaternion.identity ) as GameObject;
        playZombieDeath.transform.parent = transform;
        int num = Random.Range( 0 , ZombieDeath.Length );
        //Debug.Log(num);
        playZombieDeath.GetComponent<AudioSource>().clip = ZombieDeath[ num ];
        playZombieDeath.GetComponent<AudioSource>().Play();
    }

	// Update is called once per frame
	void Update () {
        //if( Input.GetMouseButtonDown( 1 ) )
        //{
        //    PlayShotSound();
        //    PlayBurningBottle();
        //    PlayZombileDeath();
        //}
	}
}
