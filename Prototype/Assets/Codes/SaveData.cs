using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TileItemSaveData {
    public int currentSpriteIndex;
    public string tileItemDataName;
    public TileItemSaveData(TileItemScript script) {
        this.currentSpriteIndex = script.getSpriteIndex();
        this.tileItemDataName = script.getTileItemData().name;
    }
}

[System.Serializable]
public class TileSaveData {
    public int xIndex;
    public int yIndex;
    public TileItemSaveData[] tileItemSaveDatas;
    public TileSaveData(TileScript script) {
        this.xIndex = script.getIndexX();
        this.yIndex = script.getIndexY();
        List<GameObject> tileItems = script.getTileItems();
        tileItemSaveDatas = new TileItemSaveData[tileItems.Count];
        for(int i = 0; i < tileItems.Count; i++) {
            tileItemSaveDatas[i] = new TileItemSaveData(tileItems[i].GetComponent<TileItemScript>());
        }
    }
}

[System.Serializable]
public class SaveData {
    public TileSaveData[] tileSaveDatas;
    public string test = "deneme";
    public int[] heightMap;
    public int width;
    public int height;
    public SaveData(GameObject[,] tiles, int[,] heightMapSaveData) {
        tileSaveDatas = new TileSaveData[tiles.Length];
        width = tiles.GetLength(0);
        height = tiles.GetLength(1);
        setHeightMap(heightMapSaveData);

        int currentIndex = 0;
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                tileSaveDatas[currentIndex++] = new TileSaveData(tiles[i, j].GetComponent<TileScript>());
            }
        }
    }

    private void setHeightMap(int[,] heightMapSaveData) {
        heightMap = new int[width * height];
        for(int i=0;i<width;i++)
            for (int j = 0; j < height; j++) {
                heightMap[i * height + j] = heightMapSaveData[i, j];
            }
    }

    public int[,] getHeightMap() {
        int[,] result = new int[width, height];
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++) {
                result[i, j] = heightMap[i * height + j];
            }
        return result;
    }

}
