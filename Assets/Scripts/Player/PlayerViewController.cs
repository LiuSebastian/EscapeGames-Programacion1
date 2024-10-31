using System.Collections;
using UnityEngine;

public class PlayerViewController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Inventory inventory;
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    [SerializeField] private float interactDistance;
    [SerializeField] private LayerMask interactLayerMask;
    [SerializeField] private Transform playerTransform;
    
    [SerializeField] PlayerCanvas playerCanvas;
    private float xRotation = 0f;
    private bool onInventoryOpen = false;
    [SerializeField] private bool onInteract = false;
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.position = new Vector3(0, 0.5f, 0);
        //transform.forward = playerTransform.forward;
    }


    void Update()
    {
        if(!onInventoryOpen && !onInteract)
        {
            ViewControll();
            ViewCheck();
            if (Input.GetKeyDown(KeyCode.E)) ClickMouse();
        }
    }

    void ViewControll()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
    void ViewCheck()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayerMask))
        {
            var interactObject = hit.transform.gameObject.GetComponent<InteractObject>();
            playerCanvas.InteractCrosshair(true);
        }
        else
        {
            playerCanvas.InteractCrosshair(false);
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
            interactObject.Interact(this);
        }
    }

    public void InventoryOpen(bool state)
    {
        onInventoryOpen = state;
    }

    public void OnInteract(bool state)
    {
        StartCoroutine(WaitForInteract(state));
    }

    public void LockCursor(bool locked)
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
    IEnumerator WaitForInteract(bool state)
    {
        yield return new WaitForSeconds(.2f);
        playerController.OnInteract(state);
        playerCanvas.InteractCrosshair(false);
        playerCanvas.NormalCrosshair(false);
        onInteract = state;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawRay(transform.position, transform.forward * interactDistance);
    }
    public Inventory GetInventory(){return inventory;}
}
