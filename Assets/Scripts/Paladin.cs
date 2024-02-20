using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Character
{
    public Paladin(Weapon weapon, string name) : base(weapon, name)
    {
    }

    public override void PrintStatusInfo()
    {
        Debug.LogFormat("It's override method");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
