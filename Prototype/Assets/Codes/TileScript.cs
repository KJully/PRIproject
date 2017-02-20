using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileScript : MonoBehaviour {

    List<GameObject> tileItems = new List<GameObject>();
    float tileHeight = 0;
    int xIndex, yIndex;
    bool usable = true;


    public void setPosition(float x, float y, float z){
        gameObject.transform.position = new Vector3(x, y + tileHeight, z);
    }

    public void setTileHeight(float tileHeight) {
        this.tileHeight = tileHeight;
    }

    public GameObject getGameObject(){
        return gameObject;
    }

    public GameObject addItem(TileItemData itemToAdd) {
        GameObject newItemGO = TileItemFactory.getInstance().createTileItem(itemToAdd,gameObject);
        if (newItemGO.GetComponent<TileItemScript>().checkAddable(this) == false) { Destroy(newItemGO); return null; }

        newItemGO.transform.Translate(new Vector3(0, 0, -0.01f * tileItems.Count));

        tileItems.Add(newItemGO);

        if(tileItems.Count>=2)
            tileItems[0].SetActive(false); //disable grass
        newItemGO.GetComponent<TileItemScript>().afterConstruction();

        return newItemGO;
    }

    public void clearItems() {
        for (int i = 0; i < tileItems.Count; i++) {
            Destroy(tileItems[i]);
        }
        tileItems.Clear();
    }

    public TileItemType getLastType() {
        if (tileItems.Count == 0) return TileItemType.NOTHING;
        return tileItems[tileItems.Count - 1].GetComponent<TileItemScript>().getTileItemData().itemType;
    }

    public void disableNeighborGrids(int gridSize) {
        for (int i = 0; i < gridSize; i++) {
            for (int j = 0; j < gridSize; j++) {
                if (i == 0 && j == 0) continue;
                GameObject grid = CityBuilder.getGetTileObjects()[xIndex+i, yIndex - j];
                grid.GetComponent<TileScript>().disable();
                grid.GetComponent<TileScript>().transform.Translate(0, 0, 1f);
            }
        }
    }

    public float getGridSize() {
        return tileHeight;
    }

    public float getTileHeight() {
        return tileHeight;
    }

    public void setIndex(int x, int y) {
        xIndex = x;
        yIndex = y;
    }

    public int getIndexX() {
        return xIndex;
    }
    public int getIndexY() {
        return yIndex;
    }

    public void enable() {
        usable = true;
    }

    public void disable() {
        usable = false;
    }

    public bool getUsable() {
        return usable;
    }

    public List<GameObject> getTileItems() {
        return tileItems;
    }

    public GameObject getLastTileItem() {
        if (tileItems.Count == 0) return null;
        return tileItems[tileItems.Count-1];
    }

    void Start() {
        gameObject.name = "Tile" + xIndex.ToString() + "-" + yIndex.ToString();
    }
	
	void Update () {
	
	}
}
