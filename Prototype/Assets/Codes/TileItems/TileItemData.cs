using UnityEngine;
using System.Collections;

public enum TileItemType {
    GRASS,
    ROAD,
    WATER,
    BUILDING_BASE,
    APPARTMENT,
    ROOF,
    SPECIAL,
    NOTHING
}
public enum SlopeDirections {
    NO_SLOPE = 0,
    NORTH_WEST = 1,
    NORTH = 2,
    NORTH_EAST = 3,
    EAST = 4,
    SOUTH_EAST = 5,
    SOUTH = 6,
    SOUTH_WEST = 7,
    WEST = 8
}


public class TileItemData {
    public string name;
    public TileItemType itemType;
    public float itemHeight;
    public string[] sprites;
    public TileItemType addableAfter;
    public int gridSize = 1;
    public bool singleton;
    public Color popupColor;
    public string popupText = "";
    private int usedCount = 0;
    public int currentSpriteIndex = 0;

    public TileItemData(TileItemType itemType, TileItemType addableAfter, float itemHeight, string[] sprites, string name, bool singleton) {
        this.itemType = itemType;
        this.addableAfter = addableAfter;
        this.itemHeight = itemHeight;
        this.sprites = sprites;
        this.name = name;
        this.singleton = singleton;

        if (itemType == TileItemType.SPECIAL) { // TODO
            gridSize = 2;
        }

    }
    public TileItemData(TileItemType itemType, TileItemType addableAfter, float itemHeight, string[] sprites, string name, bool singleton, Color popupColor, string popupText) {
        this.itemType = itemType;
        this.addableAfter = addableAfter;
        this.itemHeight = itemHeight;
        this.sprites = sprites;
        this.name = name;
        this.singleton = singleton;
        this.popupColor = popupColor;
        this.popupText = popupText;
        if (itemType == TileItemType.SPECIAL) { // TODO
            gridSize = 2;
        }

    }
    public void addUsedCount() {
        usedCount++;
    }
    public void decreaseUsedCount() {
        usedCount--;
    }
    public int getUsedCount() {
        return usedCount;
    }
}


