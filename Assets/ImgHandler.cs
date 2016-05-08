using UnityEngine;
using System.Collections;

public class ImgHandler : MonoBehaviour {

    public Transform t;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void OnClickedHandler()
    {
        t.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
