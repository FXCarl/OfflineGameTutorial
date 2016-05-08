using UnityEngine;
using System.Collections;

public class DestroyAudioSource : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void DestroyAudio() {
        if( transform.GetComponent<AudioSource>().clip.name != null && !transform.GetComponent<AudioSource>().isPlaying )
        {
            Destroy( gameObject ); 
        }
    }

	// Update is called once per frame
	void Update () {
        DestroyAudio();
	}
}
