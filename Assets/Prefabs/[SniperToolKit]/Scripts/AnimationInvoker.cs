using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AnimationInvoker : MonoBehaviour {

    public UnityEvent Events;

    public virtual void InvokeAnimationEvents()
    {
        Events.Invoke();
    }
}
