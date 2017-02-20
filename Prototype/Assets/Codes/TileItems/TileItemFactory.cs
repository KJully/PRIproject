using UnityEngine;
using System.Collections;

public class TileItemFactory{

    private static TileItemFactory instance;

    private TileItemFactory() {

    }

    public GameObject createTileItem(TileItemData data,GameObject parent) {
        Object newItem;
        if (data.itemType == TileItemType.SPECIAL)
            newItem = CityBuilder.Instantiate(Resources.Load("SpecialTileItem"));
        else if (data.itemType == TileItemType.ROAD)
            newItem = CityBuilder.Instantiate(Resources.Load("RoadTileItem"));
        else if (data.itemType == TileItemType.WATER)
            newItem = CityBuilder.Instantiate(Resources.Load("WaterTileItem"));
        else
            newItem = CityBuilder.Instantiate(Resources.Load("BasicTileItem"));

        Sprite sprite = ResourceManager.getInstance().getSprite(data.sprites[0]);
        GameObject newItemGO = (GameObject)newItem;

        newItemGO.GetComponent<TileItemScript>().setSprite(sprite);
        newItemGO.GetComponent<TileItemScript>().setTileItemData(data);
        if (parent != null) {
            newItemGO.GetComponent<TileItemScript>().setParentScript(parent.GetComponent<TileScript>());
            newItemGO.transform.parent = (parent.transform);
            newItemGO.transform.position = parent.transform.position;
        }
        return newItemGO;
    }

    public static TileItemFactory getInstance() {
        if (instance == null) instance = new TileItemFactory();
        return instance;
    }
}
