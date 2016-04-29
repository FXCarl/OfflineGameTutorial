using UnityEngine;
using System.Collections;

public class InputControlNextState : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            transform.GetComponent<HierarchyStateMachine>().SetNextState();
            Debug.Log("GetMouseButtonDown");
        }
	}
}
