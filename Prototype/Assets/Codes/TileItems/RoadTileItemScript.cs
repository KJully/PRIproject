using UnityEngine;
using System.Collections;
using System;

public class RoadTileItemScript : NeighborDependantItemScript {

    public override void afterConstruction() {
        spriteNamePrefix = "road";
        tileType = TileItemType.ROAD;
        base.afterConstruction();
    }

    public override bool checkAddable(TileScript tileScript) {
        if(base.checkAddable(tileScript) == false)return false;
        int x = tileScript.GetComponent<TileScript>().getIndexX();
        int y = tileScript.GetComponent<TileScript>().getIndexY();

        int tileSlope = (int)CityBuilder.getSlopeMap()[x, y];
        if (tileSlope % 2 == 1) return false; //corner
        return true;
    }
}
