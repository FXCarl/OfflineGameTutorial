using UnityEngine;
using System.Collections;

public class PerlinPan : MonoBehaviour {

    public Transform target;

    public Vector2 scale = Vector2.one;
    public Vector2 freq = Vector2.one;
    public Vector3 baseOffset = Vector3.zero;

    // Update is called once per frame
    void LateUpdate () {
        if (target == null) return;
        Vector3 offset = baseOffset;
        offset.x += scale.x * (Mathf.PerlinNoise(Time.time * freq.x, 0f) * 2f - 1f);
        offset.y += scale.y * (Mathf.PerlinNoise(0f, Time.time * freq.y) * 2f - 1f);
        target.localPosition = offset;
    }
}
