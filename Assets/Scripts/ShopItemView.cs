using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;
using System.Linq;

public class ShopItemView : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI cointText;
    public Image iconImage;
    public TextMeshProUGUI desText;
    public Image rowImage;

    private ShopItem item;
    private ShopScrollView scrollView;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(SelectedRowItem);
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(HandleClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(ShopItem item, ShopScrollView currentScrollView)
    {
        this.item = item;
        this.scrollView = currentScrollView;
        levelText.text = "Level: " + item.level.ToString();
        desText.text = "+" + item.star.ToString() + " star per passing";
        cointText.text = item.coin.ToString();

        if (this.item.isBuy)
        {
            transform.GetChild(0).GetComponent<Button>().enabled = true;
            iconImage.sprite = Resources.LoadAll<Sprite>("Sprites/Ball sprite").SingleOrDefault(o => o.name.Equals(item.itemName));
        }
        else
        {
            transform.GetChild(0).GetComponent<Button>().enabled = false;
            iconImage.sprite = Resources.Load<Sprite>("Images/lock-icon");
        }

        if (this.item.selected)
        {
            rowImage.sprite = Resources.Load<Sprite>("Images/frame-cell-selected");
        }
        else
        {
            rowImage.sprite = Resources.Load<Sprite>("Images/frame-cell");
        }

        //Debug.Log("item selected aaa: " + item.selected);
    }

    public void HandleClick()
    {
        Debug.Log("buying: " + item.itemName);
        scrollView.ButtonClicked(item);
        //scrollView.TryTransferItemToOtherShop(item);
    }

    public void SelectedRowItem()
    {
        if (!item.isBuy) return;
        item.selected = true;
        Debug.Log("selected row: " + item.selected);
        
        scrollView.SelectedRowItem(item);
    }
}
