using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ConnectWires : MonoBehaviour
{
    [SerializeField] ElectricWires ElectricWires;
    [SerializeField] private Wire startWire;
    [SerializeField] private Wire finishWire;
    [SerializeField] bool isGrabing = false;
    [SerializeField] private float radius;
    [SerializeField] LayerMask wireLayerMask;
    [SerializeField] Collider[] colliders;
    
    public void GetWires(bool state)
    {
        isGrabing = state;
        if (state)
        {
            colliders = Physics.OverlapSphere(transform.position, radius, wireLayerMask);
            if (colliders.Length != 0)
            {
                foreach (var obj in colliders)
                {
                    var wire = obj.gameObject.GetComponent<Wire>();
                    if(wire.GetWireType() == WireType.Start) startWire = wire;
                    else finishWire = wire;
                }
            }
            if (startWire != null && !startWire.IsConnected())
            {
                startWire.SetPosition(transform);
            }
            
            if (startWire != null && finishWire != null && startWire.GetColor() == finishWire.GetColor() && !startWire.IsConnected())
            {
                startWire.Connect(finishWire);
                ElectricWires.ConnectWiresColor(startWire.GetColor());
            }
        }
        else
        {
            if(startWire != null) startWire.ResetPosition();
            if(finishWire != null) finishWire.ResetPosition();
            startWire = null;
            finishWire = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
