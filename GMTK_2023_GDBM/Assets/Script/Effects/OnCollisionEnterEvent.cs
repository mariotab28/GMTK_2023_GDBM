using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionEnterEvent : MonoBehaviour
{
    
    public List<UnityEvent> events;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var ev in events)
        {
            ev.Invoke();
        }
    }
}
