using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopControler : MonoBehaviour
{
    public GameObject ControlPanel;
    public GameObject ShopPrefab;


    public ListController LoadShop()
    {
        print("loading shop");
        GameObject newShop = Instantiate(ShopPrefab) as GameObject;

        newShop.transform.SetParent(ControlPanel.transform, false);
        newShop.transform.localScale = Vector3.one;

        return newShop.GetComponent<ListController>();
    }

}
