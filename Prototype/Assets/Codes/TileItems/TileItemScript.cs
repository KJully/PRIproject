using UnityEngine;
using System.Collections;

public class TileItemScript : MonoBehaviour {

    protected TileScript parentScript;
    protected TileItemData tileItemData;
    protected int currentSpriteIndex = 0;
    protected bool useCollider = true;

    public void setSprite(Sprite sprite) {
        GetComponent<SpriteRenderer>().sprite = sprite;
        Bounds spriteBounds = sprite.bounds;
        if(useCollider)
            gameObject.AddComponent<PolygonCollider2D>();
    }

    public void setUseCollider(bool useCollider) {
        this.useCollider = useCollider;
    }

    public bool getUseCollider() {
        return useCollider;
    }

    public void setParentScript(TileScript parentScript) {
        this.parentScript = parentScript;
    }

    public TileScript getParentScript() {
        return parentScript;
    }

    public void setSpriteIndex(int spriteIndex) {
        currentSpriteIndex = spriteIndex;
        setSprite(ResourceManager.getInstance().getSprite(tileItemData.sprites[currentSpriteIndex % tileItemData.sprites.Length]));
    }

    public int getSpriteIndex() {
        return currentSpriteIndex;
    }

    public void setTileItemData(TileItemData tileItemData) {
        this.tileItemData = tileItemData;
    }

    public TileItemData getTileItemData() {
        return tileItemData;
    }

    public virtual void itemClicked() {
        if (tileItemData.popupText != null && tileItemData.popupText.Length>0) {
            GUIManager.getInstance().showPopup(tileItemData.popupColor, tileItemData.popupText);
        }
    }

    public virtual void afterConstruction() {
        if (tileItemData.gridSize > 1) {
            parentScript.disableNeighborGrids(tileItemData.gridSize);
        }
        tileItemData.addUsedCount();
    }

    public virtual bool checkAddable(TileScript tileScript) {
        if (tileItemData.singleton && tileItemData.getUsedCount() > 0) return false;
        if (tileScript.getUsable() == false) return false;

        int xIndex = tileScript.getIndexX();
        int yIndex = tileScript.getIndexY();
        for (int i = 0; i < tileItemData.gridSize; i++) {
            for (int j = 0; j < tileItemData.gridSize; j++) {
                if (xIndex + i < 0 || yIndex - j < 0 || xIndex + i + 1 > CityBuilder.MAP_WIDTH || yIndex - j + 1 > CityBuilder.MAP_HEIGHT) {
                    return false;
                }
                GameObject grid = CityBuilder.getGetTileObjects()[xIndex + i, yIndex - j];
                TileItemType gridsLastType = grid.GetComponent<TileScript>().getLastType();
                if (gridsLastType != tileItemData.addableAfter && gridsLastType != TileItemType.NOTHING) {
                    return false;
                }
                if (grid.GetComponent<TileScript>().getTileHeight() != tileScript.getTileHeight()) {
                    return false;
                }
            }
        }

        return true;
    }

    void Start() {
    }

    void Update() {

    }
}
