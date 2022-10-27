using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightItem : Item
{
    [SerializeField] private int id = 0;
    private Light _light = null;
    private const int OnValue = 10;
    private const int OffValue = 0;
    
    // Start is called before the first frame update
    private void Start()
    {
        _light = GetComponentInChildren<Light>();
        _light.intensity = OffValue;
    }

    public override void Act()
    {
        ToggleLight();
    }

    public override void AdvanceState(int id)
    {
        Debug.Log("Nothing happens");
    }

    public bool IsOn()
    {
        return Math.Abs(_light.intensity - OnValue) < 0.01;
    }

    private void ToggleLight()
    {
        _light.intensity = IsOn() ? OffValue : OnValue;
    }

    public int GetId()
    {
        return id;
    }
}
