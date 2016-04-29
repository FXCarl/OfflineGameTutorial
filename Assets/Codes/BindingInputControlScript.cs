using UnityEngine;
using System.Collections;

public class BindingInputControlScript : MonoBehaviour {

    public GameObject[] obj;
	// Use this for initialization
	void Start () {
        obj = new GameObject[transform.childCount];
        //Debug.Log(transform.childCount);
        //Debug.Log(transform.GetChild(0).name);
        for (int i = 0; i < transform.childCount; i++)
        {
            obj[i] = transform.GetChild(i).gameObject;
            obj[i].AddComponent<InputControlNextState>(); 
            Debug.Log(obj[i].name);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
