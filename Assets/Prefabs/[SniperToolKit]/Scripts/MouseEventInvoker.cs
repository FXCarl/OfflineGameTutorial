using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseEventInvoker : MonoBehaviour {

	public UnityEvent EventsClick;
	public UnityEvent EventsMoved;

	private Vector2 mousePos = Vector2.zero;
	// Update is called once per frame
	void OnMouseDown () {
		mousePos = Input.mousePosition;
	}

	void OnMouseUp (){
		if (Vector2.Distance (Input.mousePosition, mousePos) / Screen.dpi < 0.1f)
			EventsClick.Invoke ();
	}

	void Update(){
		if (Input.GetMouseButtonDown (0) && (Vector2.Distance(mousePos, Input.mousePosition) / Screen.dpi) > 0.1f ) {
			EventsMoved.Invoke();
		}
	}
}
