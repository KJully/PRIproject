using UnityEngine;
using System.Collections;
using System;

public class NeighborDependantItemScript : TileItemScript {
    protected string spriteNamePrefix;
    protected TileItemType tileType;

    public override void afterConstruction() {
        calculateNewSprite(true);
    }

    public override bool checkAddable(TileScript tileScript) {
        if(base.checkAddable(tileScript) == false)return false;
        int x = tileScript.GetComponent<TileScript>().getIndexX();
        int y = tileScript.GetComponent<TileScript>().getIndexY();

        int tileSlope = (int)CityBuilder.getSlopeMap()[x, y];
        if (tileSlope % 2 == 1) return false; //corner
        return true;
    }

    public void calculateNewSprite(bool updateNeighbor) {
        int x = parentScript.GetComponent<TileScript>().getIndexX();
        int y = parentScript.GetComponent<TileScript>().getIndexY();

        GameObject[,] tiles = CityBuilder.getGetTileObjects();
        string spriteName = spriteNamePrefix;

        if (x + 2 < tiles.GetLength(0) && tiles[x + 1, y].GetComponent<TileScript>().getLastType() == tileType) {      // NORTH
            spriteName += "1";
            if (updateNeighbor)tiles[x + 1, y].GetComponent<TileScript>().getLastTileItem().GetComponent<NeighborDependantItemScript>().calculateNewSprite(false);
        }
        else {
            spriteName += "0";
        }

        if (y - 1 >= 0 && tiles[x, y - 1].GetComponent<TileScript>().getLastType() == tileType) {                      // EAST
            spriteName += "1";
            if (updateNeighbor)tiles[x, y - 1].GetComponent<TileScript>().getLastTileItem().GetComponent<NeighborDependantItemScript>().calculateNewSprite(false);
        }
        else {
            spriteName += "0";
        }

        if (x - 1 >= 0 && tiles[x - 1, y].GetComponent<TileScript>().getLastType() == tileType) {                      // SOUTH
            spriteName += "1";
            if (updateNeighbor) tiles[x - 1, y].GetComponent<TileScript>().getLastTileItem().GetComponent<NeighborDependantItemScript>().calculateNewSprite(false);
        }
        else {
            spriteName += "0";
        }

        if (y + 2 <= tiles.GetLength(1) && tiles[x, y + 1].GetComponent<TileScript>().getLastType() == tileType) {     // WEST
            spriteName += "1";
            if (updateNeighbor) tiles[x, y + 1].GetComponent<TileScript>().getLastTileItem().GetComponent<NeighborDependantItemScript>().calculateNewSprite(false);
        }
        else {
            spriteName += "0";
        }

        int tileSlope = (int)CityBuilder.getSlopeMap()[x, y];
        if ( tileSlope != 0 ) {
            string slopeSprite = spriteNamePrefix + "Slope" +((tileSlope + 1) / 2).ToString();
            setSpriteIndex(Array.IndexOf(tileItemData.sprites, slopeSprite));
            return;
        }

        setSpriteIndex(Array.IndexOf(tileItemData.sprites, spriteName));
    }
}
