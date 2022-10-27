using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightItem : Item
{
    private Light _light = null;
    private const int _onValue = 10;
    private const int _offValue = 0;
    
    // Start is called before the first frame update
    private void Start()
    {
        _light = GetComponentInChildren<Light>();
        _light.intensity = _offValue;
    }

    public override void Act()
    {
        ToggleLight();
    }

    public bool IsOn()
    {
        return Math.Abs(_light.intensity - _onValue) < 0.01;
    }

    private void ToggleLight()
    {
        _light.intensity = IsOn() ? _offValue : _onValue;
    } 
}
