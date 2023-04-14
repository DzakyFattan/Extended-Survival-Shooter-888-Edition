using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OntoMainMenu : MonoBehaviour
{
    [SerializeField] private UnityEvent onFromEnd;
    void Start()
    {
        if (Global.loadedFrom == Global.LoadedFrom.End)
        {
            Global.loadedFrom = Global.LoadedFrom.Any;
            onFromEnd.Invoke();
        }
    }
}
