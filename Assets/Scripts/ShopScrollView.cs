using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;

public class ShopScrollView : MonoBehaviour
{
    public List<ShopItem> shopItems;
    public Transform contentPanel;
    public ObjectPool objectPool;
    //public ShopData shopData;
    public AlertDialog alert;

    // Start is called before the first frame update
    void Start()
    {
        LoadShopItems();
        RefreshDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadShopItems()
    {
        List<ShopItem> listItems = SaveSystem.LoadShopItems();
        if(listItems != null)
        {
            shopItems = listItems;
        }
    }

    public void RefreshDisplay()
    {
        RemoveAllItem();
        AddButtons();
    }

    private void AddButtons()
    {
        for (int i = 0; i < shopItems.Count; i++)
        {
            ShopItem item = shopItems[i];
            
            GameObject newCellItem = objectPool.GetObject();
            
            newCellItem.transform.SetParent(contentPanel);
            newCellItem.transform.localScale = new Vector3(1, 1, 1);

            ShopItemView itemView = newCellItem.GetComponent<ShopItemView>();
            itemView.Setup(item, this);
        }
    }
    
    private void RemoveItem (ShopItem item)
    {
        shopItems.RemoveAll(x => x == item);
    }

    private void RemoveAllItem ()
    {
        while(contentPanel.childCount > 0)
        {
            GameObject toRemove = contentPanel.transform.GetChild(0).gameObject;
            if (toRemove)
                objectPool.ReturnObject(toRemove);
        }
    }

    public void ButtonClicked(ShopItem item)
    {

        GameSession gameSession = FindObjectOfType<GameSession>();
        int currentCoin = gameSession.GetCoin();
        if (currentCoin < item.coin)
        {
            Debug.Log("dont enough");
            alert.ShowMessage("You don't have enough stars!!!");
        }
        else
        {
            gameSession.SubtractCoin(item.coin);
            shopItems.FirstOrDefault(x => x.itemName == item.itemName).UpdatedNextLevel();
            SaveSystem.SaveShopItems(shopItems);
            RefreshDisplay();

            AnalyticsEvent.Custom("Item", new Dictionary<string, object>
            {
                { "item_name", item.itemName },
                { "item_level", item.level },
                { "time_elapsed", Time.timeSinceLevelLoad }
            });
        }

    }

    public void SelectedRowItem(ShopItem item)
    {
        shopItems.Select(o => { o.selected = true && o == item; return o; }).ToList();
        SaveSystem.SaveShopItems(shopItems);
        RefreshDisplay();
    }
}
