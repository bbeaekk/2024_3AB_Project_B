using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCallback : MonoBehaviour
{
    private Action greetingAction;

    // Start is called before the first frame update
    void Start()
    {
        greetingAction = SayHello;
        PerformGreeting(greetingAction);
    }

    // Update is called once per frame
    void SayHello()
    {
        Debug.Log("Hello,world");
    }

    void PerformGreeting(Action greetingFunc)
    {
        greetingFunc?.Invoke();
    }
}
