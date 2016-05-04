using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudoDemo : MonoBehaviour {

    public AudioClip[] audos;

    public Dictionary<string, AudioClip> audoclipMapping;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < audos.Length; i++)
        {
            audoclipMapping.Add(audos[i].name, audos[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
