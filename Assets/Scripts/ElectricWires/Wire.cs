using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public enum WireColor { Red, Green, Blue};
public enum WireType { Start, Finish};

public class Wire : MonoBehaviour
{
    [SerializeField] private WireColor color;
    [SerializeField] private WireType type;
    [SerializeField] private Wire connection;
    [SerializeField] private bool connected;
    [SerializeField] private GameObject cable;

    [SerializeField] Vector3 initialScale;
    private Transform initialTransform;
    private void Start()
    {
        if(cable!=null) initialTransform = cable.transform;
    }

    public void ResetPosition()
    {
        if(cable!=null)cable.transform.rotation = new Quaternion(0, 0, -90, 0);
        if(cable!=null)cable.transform.localScale = initialScale;
        if(cable!=null)cable.transform.position = initialTransform.position;
    }
    public void SetPosition(Transform newPosition)
    {
        var dist = Vector3.Distance(transform.position, newPosition.transform.position);
        cable.transform.localScale = new Vector3(initialScale.x, dist, initialScale.z);
        
        Vector3 middlePoint = (transform.position + newPosition.transform.position) * 0.5f;
        cable.transform.position = middlePoint;

        Vector3 newRotation = (newPosition.transform.position - transform.position);
        cable.transform.up = newRotation;
    }
    public void Connect(Wire wire)
    {
        if (type == WireType.Finish) return;
        //if(connection != null ) 
        SetPosition(connection.transform);
        //connection = wire;
        connected = true;
    }
    public WireColor GetColor()
    {
        return color;
    }

    public WireType GetWireType()
    {
        return type;
    }

    public void SetConnected(bool state)
    {
        connected = state;
    }
    public bool IsConnected(){return connected;}
}
