using UnityEngine;
using System.Collections;

public class MovingLimit : MonoBehaviour {

    public BoxCollider Volume;

	// Update is called once per frame
	void Update () {
        if (Volume == null) return;
        if (!Volume.bounds.Contains(transform.position))
            transform.position = Volume.ClosestPointOnBounds(transform.position);
	}
}
