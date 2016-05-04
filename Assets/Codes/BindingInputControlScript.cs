using UnityEngine;
using System.Collections;

public class BindingInputControlScript : MonoBehaviour {

    public GameObject[] obj;
    public GameObject[] Act;
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
            BindingAudioSources(obj[i]);
        }
    }

    private void BindingAudioSources(GameObject _obj) {
        if (_obj.ToString().StartsWith("Act"))
        {
            Act = new GameObject[_obj.transform.childCount];
            for (int i = 0; i < _obj.transform.childCount; i++)
            {
                Act[i] = _obj.transform.GetChild(i).gameObject;
                Act[i].AddComponent<AudioSource>();
            }
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
