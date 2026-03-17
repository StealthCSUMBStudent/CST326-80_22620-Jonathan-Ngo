using System;
using UnityEngine;


//PascalCase - properties and events
//camelCase - fields
//sanke_case - constants
public class MyCodeStyle : MonoBehaviour
{
    public const int CONSTANT_FIELD = 56;

    public static MyCodeStyle Instance
    {
        get;
        private set;
    }

    public event EventHandler OnSomethingHappened;

    private float memberVariable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Instance = this;
        DoSomething(10f);
    }

    private void DoSomething (float time)
    {
        //Do Something
        memberVariable = time + Time.deltaTime;
        if (memberVariable > 0)
        {
            //Do Something else
        }

    }
}
