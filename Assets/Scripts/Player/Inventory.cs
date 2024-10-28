using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] PlayerViewController playerViewController;
    [SerializeField] private Transform content;
    [SerializeField] private Transform hand;
    Dictionary<Item, Sprite> items = new Dictionary<Item, Sprite>();
    [SerializeField] InventoryItem itemPref;
    private Animator anim;
    private Item currentItem;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            playerViewController.InventoryOpen(true);
            anim.SetBool("Open", true);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerViewController.InventoryOpen(false);
            anim.SetBool("Open", false);
        }
    }

    public void SelectItem(Item item)
    {
        DeselectItem();
        item.gameObject.SetActive(true);
        currentItem = item;
    }

    public void DeselectItem()
    {
        if(currentItem != null) currentItem.gameObject.SetActive(false);
        currentItem = null;
    }
    public void PickUpItem(Item item)
    {
        item.transform.position = hand.position;
        item.transform.forward = hand.forward;
        item.transform.parent = hand;
        items.Add(item, item.GetItemSprite());
        var newItem = Instantiate(itemPref, content);
        newItem.SetUp(item, item.GetItemSprite(), item.GetItemName(), this);
    }
}
