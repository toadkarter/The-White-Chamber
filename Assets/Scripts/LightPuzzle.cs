using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightPuzzle : MonoBehaviour
{
    [SerializeField] private List<LightItem> lamps = new List<LightItem>();
    [SerializeField] private Transform bookShelf;
    private List<int> _order = new List<int> {2, 1, 3, 4};
    private bool _onCorrectPath = false;
    private int currentLitLamps = 0;

    private bool AllLampsOff()
    {
        var lampStatus = true;
        foreach (var lamp in lamps.Where(lamp => lamp.IsOn()))
        {
            lampStatus = false;
        }

        return lampStatus;
    }

    private bool AllLampsOn()
    {
        var lampStatus = true;
        foreach (var lamp in lamps.Where(lamp => !lamp.IsOn()))
        {
            lampStatus = false;
        }
        return lampStatus;
    }

    public void PlayPuzzle()
    {
        if (PuzzleSolved()) { return; }
        if (AllLampsOff()) {_onCorrectPath = true;}
        if (!_onCorrectPath && !AllLampsOff()) { return; }
        
        int numberOfLitLamps = GetNumberOfLitLamps();
        if (numberOfLitLamps < currentLitLamps)
        {
            _onCorrectPath = false;
            currentLitLamps = numberOfLitLamps;
            return;
        } 
        if (numberOfLitLamps == 0)
        {
            currentLitLamps = numberOfLitLamps;
            return;
        }

        Debug.Log("Comparing lamps");
        currentLitLamps = numberOfLitLamps;
        for (var i = 0; i < currentLitLamps; i++)
        {
            Debug.Log(i);
            if (!LampWithIdIsOn(_order[i]))
            {
                _onCorrectPath = false;
            }
        }
    }

    private bool LampWithIdIsOn(int id)
    {
        return lamps.Where(lamp => lamp.GetId() == id)
            .Select(lamp => lamp.IsOn())
            .FirstOrDefault();
    }

    private int GetNumberOfLitLamps()
    {
        return lamps.Count(lamp => lamp.IsOn());
    }

    private bool PuzzleSolved()
    {
        if (!(_onCorrectPath && AllLampsOn())) return false;
        return true;
    }
}
