using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresButton : MonoBehaviour
{
    [SerializeField] ElectricWires electricWire;
    [SerializeField] private bool isActivateLightsButton;
    [SerializeField] private bool isResetButton;

    public void ActivateLights()
    {
        if(isActivateLightsButton) electricWire.ActivateLight();
        if(isResetButton) electricWire.ResetWires();
    }
}
