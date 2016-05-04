using UnityEngine;
using System.Collections;

public class BindingScript : MonoBehaviour
{

    private GameObject[] obj;
    private GameObject[] Act;

    private AudioSourceConfig AudioSource;
    // Use this for initialization
    void Start()
    {
        //AudioSource = new AudioSourceConfig();

        obj = new GameObject[transform.childCount];
        //Debug.Log(transform.childCount);
        //Debug.Log(transform.GetChild(0).name);
        for (int i = 0; i < transform.childCount; i++)
        {
            obj[i] = transform.GetChild(i).gameObject;
            //obj[i].AddComponent<InputControlNextState>();
            //Debug.Log(obj[i].name);
            BindingAudioSources(obj[i]);
            BindingInputControl(obj[i]);
        }
    }

    private void BindingAudioSources(GameObject _obj)
    {
        if (_obj.ToString().StartsWith("Act"))
        {
            Act = new GameObject[_obj.transform.childCount];
            for (int i = 0; i < _obj.transform.childCount; i++)
            {
                Act[i] = _obj.transform.GetChild(i).gameObject;
                Act[i].AddComponent<AudioSource>();
                Act[ i ].GetComponent<AudioSource>().loop = false;
                //Debug.Log( Act[ i ].name );
                //Act[ i ].GetComponent<AudioSource>().clip = AudioSource.
            }
        }
    }

    private void BindingInputControl(GameObject _obj)
    {
        if (_obj.ToString().StartsWith("Act"))
        {
            _obj.AddComponent<InputControlNextState>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
