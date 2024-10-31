using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;


public class ElectricWires : InteractObject
{
    private PlayerViewController _player;
    [SerializeField] GameObject[] electricLeftWire;
    [SerializeField] GameObject[] electricRighttWire;
    [SerializeField] GameObject[] cables;
    [SerializeField] private bool onInteract = false;
    [SerializeField] private LayerMask wireLayerMask;
    [SerializeField] private Camera camera;
    [SerializeField] ConnectWires connectWires;
    Dictionary<WireColor, bool> wireColors = new Dictionary<WireColor, bool>();
    [SerializeField] private bool Open;
    [SerializeField] private GameObject electricConnection;
    IElectric _electric;
    [SerializeField] Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
        _electric = electricConnection.GetComponent<IElectric>();
        WireColor[] wireColor = (WireColor[]) Enum.GetValues(typeof(WireColor));

        for (int i = 0; i < wireColor.Length; i++)
        {
            wireColors.Add(wireColor[i], false);
        }
        ShuffleWires();
        
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

        for (int i = 0; i < electricRighttWire.Length - 1; i++)
        {
            var current = electricRighttWire[i].transform.position;
            int rand = Random.Range(0, electricRighttWire.Length);
            electricRighttWire[i].transform.position = electricRighttWire[rand].transform.position;
            electricRighttWire[rand].transform.position = current;
        }
    }

    public void ConnectWiresColor(WireColor color)
    {
        if (!wireColors.ContainsKey(color)) return;
        wireColors[color] = true;
        foreach (var key in wireColors)
        {
            if (!key.Value) return;
        }
        ExitInteraction();
        _electric.Open();
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

    private void OnDrawGizmos()
    {
        // Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        // //mousePosition.z = 0f;
        // Vector3 direction = mousePosition - mainCamera.transform.position;
        // //direction.z = 0f;
        // Gizmos.DrawRay(Camera.main.transform.position, direction);
    }
}
