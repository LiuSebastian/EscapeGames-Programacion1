using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerViewController : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    [SerializeField] private float interactDistance;
    [SerializeField] private LayerMask interactLayerMask;
    [SerializeField] private Transform playerTransform;

    private float xRotation = 0f;
    private InteractObject lastItemHit;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.position = new Vector3(0, 0.5f, 0);
        transform.forward = playerTransform.forward;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerTransform.Rotate(Vector3.up * mouseX);
        ViewCheck();
        if (Input.GetKeyDown(KeyCode.E)) ClickMouse();
    }
    void ViewCheck()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayerMask))
        {
            var interactObject = hit.transform.gameObject.GetComponent<InteractObject>();
            if (interactObject == null)
            {
                if(lastItemHit != null) lastItemHit.OnInteractRange(false);
                lastItemHit = null;
                return;
            }

            lastItemHit = interactObject;
            interactObject.OnInteractRange(true);
        }
        else
        {
            if(lastItemHit != null) lastItemHit.OnInteractRange(false);
            lastItemHit = null;
        }
    }
    void ClickMouse()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayerMask))
        {
            if (hit.transform == null) return;
            var interactObject = hit.transform.gameObject.GetComponent<InteractObject>();
            if (interactObject == null) return;
            interactObject.Interact();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawRay(transform.position, transform.forward * interactDistance);
    }
}
