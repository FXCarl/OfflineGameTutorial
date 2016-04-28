using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomFillUtility : MonoBehaviour {

    public Camera SniperCamera;
    public List<Transform> Anchors;
    public List<Object> Prefabs;

    private List<Transform> m_TodoAnchors = new List<Transform>();

    void OnEnable()
    {
        StartCoroutine(Fill());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

	// Use this for initialization
	IEnumerator Fill () {
        while (enabled && Application.isPlaying)
        {
            CheckAnchors();
            RemoveInViewAnchors();
            FillAnchors();
            yield return new WaitForSeconds(1f);
        }
	}

    void CheckAnchors()
    {
        m_TodoAnchors.Clear();
        m_TodoAnchors.AddRange(Anchors);
        if (m_TodoAnchors != null && m_TodoAnchors.Count > 0)
        {
            m_TodoAnchors.RemoveAll((trs) => (trs == null || trs.childCount > 0));
        }
    }

    void RemoveInViewAnchors()
    {
        if(SniperCamera != null && m_TodoAnchors != null && m_TodoAnchors.Count > 0)
        {
            m_TodoAnchors.RemoveAll((trs) => (Vector3.Scale(SniperCamera.WorldToViewportPoint(trs.position), new Vector3(1.0f, 1.0f, 0.0f)).sqrMagnitude < 1f));
        }
    }

    void FillAnchors()
    {
        if(m_TodoAnchors != null && m_TodoAnchors.Count > 0 && Prefabs != null && Prefabs.Count > 0)
        {
            for(int i=0; i< m_TodoAnchors.Count; i++)
            {
                GameObject go = Instantiate(Prefabs[Random.Range(0, Prefabs.Count)]) as GameObject;
                go.transform.parent = m_TodoAnchors[i].transform;
                go.transform.localPosition = Vector3.zero;
            }
        }
    }
}
