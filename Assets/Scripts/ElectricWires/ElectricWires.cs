using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ElectricWires : InteractObject
{
    private PlayerViewController _player;
    [SerializeField] GameObject[] electricLeftWire;
    [SerializeField] GameObject[] electricRightWire;
    [SerializeField] Wire[] cables;
    [SerializeField] private bool onInteract = false;
    [SerializeField] private LayerMask wireLayerMask;
    [SerializeField] private Camera camera;
    [SerializeField] ConnectWires connectWires;
    Dictionary<WireColor, bool> wireColors = new Dictionary<WireColor, bool>();
    [SerializeField] private bool Open;
    [SerializeField] private GameObject electricConnection;
    IElectric _electric;
    [SerializeField] Camera mainCamera;

    [SerializeField] Light mainLight;
    [SerializeField] private Color red;
    [SerializeField] private Color green;
    [SerializeField] private Color blue;
    [SerializeField] private Color brownColor;
    [SerializeField] private Color violetColor;
    [SerializeField] private Color cianColor;
    [SerializeField] private Color whiteColor;
    [SerializeField] private Color blackColor;
    private void Start()
    {
        mainCamera = Camera.main;
        _electric = electricConnection.GetComponent<IElectric>();
        WireColor[] wireColor = (WireColor[]) Enum.GetValues(typeof(WireColor));

        for (int i = 0; i < wireColor.Length; i++)
        {
            wireColors.Add(wireColor[i], false);
        }

        ActivateLight();
        //ShuffleWires();
    }

    private void Update()
    {
        if (onInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ExitInteraction();
            }
            ConnectWiresMouse();
            ConnectWires(Input.GetKey(KeyCode.Mouse0));
        }
    }
    void ConnectWires(bool state)
    {
        connectWires.GetWires(state);
    }
    void ConnectWiresMouse()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, camera.nearClipPlane));
        Vector3 direction = camera.transform.forward;
        connectWires.transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, connectWires.transform.position.z);
        Debug.DrawRay(mouseWorldPosition, direction * 2, Color.red);
    }
    void ShuffleWires()
    {
        for (int i = 0; i < electricLeftWire.Length - 1; i++)
        {
            var current = electricLeftWire[i].transform.position;
            int rand = Random.Range(0, electricLeftWire.Length);
            
            electricLeftWire[i].transform.position = electricLeftWire[rand].transform.position;
            electricLeftWire[rand].transform.position = current;
            
            cables[i].transform.position = cables[rand].transform.position;
            cables[rand].transform.position = current;
        }

        for (int i = 0; i < electricRightWire.Length; i++)
        {
            var current = electricRightWire[i].transform.position;
            int rand = Random.Range(0, electricRightWire.Length);
            electricRightWire[i].transform.position = electricRightWire[rand].transform.position;
            electricRightWire[rand].transform.position = current;
        }
    }

    public void ActivateLight()
    {
        Debug.Log( GetWireColors());
        mainLight.color = GetWireColors();
    }
    Color GetWireColors()
    {
        if (wireColors[WireColor.Red] && !wireColors[WireColor.Green] && wireColors[WireColor.Blue])
        {
            //Hacer algo
            return violetColor;
        }
        if (!wireColors[WireColor.Red] && wireColors[WireColor.Green] && wireColors[WireColor.Blue])
        {
            //Hacer algo
            return cianColor;
        }
        if (wireColors[WireColor.Red] && wireColors[WireColor.Green] && !wireColors[WireColor.Blue])
        {
            //Hacer algo
            return brownColor;
        }
        if (wireColors[WireColor.Red] && wireColors[WireColor.Green] && wireColors[WireColor.Blue])
        {
            //Hacer algo
            return whiteColor;
        }
        if (wireColors[WireColor.Red]) return red;
        if (wireColors[WireColor.Green]) return green;
        if (wireColors[WireColor.Blue]) return blue;
        return blackColor;
    }
    public void ConnectWiresColor(WireColor color)
    {
        if (!wireColors.ContainsKey(color)) return;
        wireColors[color] = true;

        //ExitInteraction();
        //_electric.Open();
    }
    void ExitInteraction()
    {
        _player.LockCursor(true);
        _player.OnInteract(false);
        onInteract = false;
        mainCamera.enabled = true;
        camera.gameObject.SetActive(false);
    }
    public override void Interact(PlayerViewController player)
    {
        if (_player == null) _player = player;
        if(!onInteract && !Open)
        {
            mainCamera.enabled = false;
            camera.gameObject.SetActive(true);
            _player.LockCursor(false);
            _player.OnInteract(true);
            onInteract = true;
        }
    }
    public void ResetWires()
    {
        foreach (var cable in cables)
        {
            cable.SetConnected(false);
            cable.ResetPosition();
        }
        wireColors[WireColor.Red] = false;
        wireColors[WireColor.Green] = false;
        wireColors[WireColor.Blue] = false;
        mainLight.color = GetWireColors();
    }
}
