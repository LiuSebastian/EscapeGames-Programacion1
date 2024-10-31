using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    private Item _item;
    [SerializeField] Image spriteRenderer;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] Inventory _inventory;
    private void Start()
    {
        spriteRenderer = GetComponent<Image>();
        
    }

    public void SetUp(Item item, Sprite sprite, string name, Inventory inventory)
    {
        _item = item;
        spriteRenderer.sprite = sprite;
        text.text = name;
        _inventory = inventory;
    }

    public void SelectItem()
    {
        _item.OnSelectItem(true);
        _inventory.SelectItem(_item);
        _item.PlayAnimation("OnHand");
    }
}
