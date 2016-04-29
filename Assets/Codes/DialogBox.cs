using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {

    public GameObject Left;
    public GameObject Right;

    public bool left;
    public string dialog;
    public int headIconIndex;

    private GameObject dialogGo;

    void OnEnable()
    {
        dialogGo = Setup(left, dialog, headIconIndex);
    }

    void OnDisable()
    {
        if (dialogGo) Destroy(dialogGo);
    }

    public GameObject Setup(bool left, string diablog, int index)
    {
        GameObject go = Instantiate(left?Left:Right) as GameObject;
        go.transform.parent = this.transform;
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;
        Text text = go.GetComponentInChildren<Text>();
        if (text) text.text = diablog;
        Transform heads = go.transform.FindChild("HeadIcons");

        if (heads)
        {
            foreach (Transform child in heads)
            {
                child.gameObject.SetActive(child.GetSiblingIndex() == index);
            }
        }

        return go;
    }
    	
}
