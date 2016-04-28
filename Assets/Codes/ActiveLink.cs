using UnityEngine;
using System.Collections;

public class ActiveLink : MonoBehaviour {

    public GameObject LinkTarget;

	void OnEnable()
    {
        LinkTarget.SetActive(true);
    }

    void OnDisable()
    {
        LinkTarget.SetActive(false);
    }
}
