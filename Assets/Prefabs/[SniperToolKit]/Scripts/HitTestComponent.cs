using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class HitTestComponent : FireHandler
{
    public override void Fire()
    {
        Collider2D result = Physics2D.OverlapPoint(transform.position);
        if (result == null) return;
        result.SendMessage("Fire");
    }
}
