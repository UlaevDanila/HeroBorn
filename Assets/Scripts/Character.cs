using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public struct Weapon
{
    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    public void PrintWeaponStats()
    {
        Debug.LogFormat("Weapon name: {0}, damage: {1}", name, damage);
    }
    
    [CanBeNull] public string name;
    
    public int damage;
}


public class Character
{
    public Weapon weapon;
    
    [CanBeNull] public string name;
    
    public int xp = 0;
    
    public Character(Weapon weapon, string name, int xp)
    {
        this.weapon = new Weapon("sword", 100);
        this.name = name;
        this.xp = xp;
    }

    public Character(Weapon weapon, string name)
    {
        this.weapon = weapon;
        this.name = name;
    }

    public Character()
    {
        weapon = new Weapon("sword", 100);
        name = "Base constructed";
        xp = 0;
    }

    public Character(Character reference)
    {
        weapon = reference.weapon;
        name = reference.name;
        xp = reference.xp;
    }
    
    public virtual void PrintStatusInfo()
    {
        Debug.LogFormat("Hero: {0}, XP: {1}, Weapon name: {2}, Weapon damage: {3}", name, xp, weapon.name, weapon.damage);
    }

    private void Reset()
    {
        this.name = "Not assigned";
        this.xp = 0;
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
