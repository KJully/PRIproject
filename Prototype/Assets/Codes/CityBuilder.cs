using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CityBuilder : MonoBehaviour {

    public static readonly int MAP_WIDTH = 30;
    public static readonly int MAP_HEIGHT = 30;
    public static readonly float GRID_WIDTH = 0.65f;
    public static readonly float GRID_HEIGHT = 0.32f;
    public static readonly float GRID_DEPTH = 0.32f;
    public static readonly float Z_PER_TILE = 1f;
    public static string SAVE_FILE_PATH;

    private static GameObject[,] tileObjects = new GameObject[MAP_WIDTH, MAP_HEIGHT];
    private static int[,] heightMap;
    private static SlopeDirections[,] slopeMap;

    private SaveData loadedData;

    void Start () {
        SAVE_FILE_PATH = Application.dataPath + "/savegame.txt";
        loadGameData();
        SceneManager.LoadScene("guiScene", LoadSceneMode.Additive);
        if(loadedData != null) {
            RandomMapGenerator.getInstance().loadHeightMap(loadedData.getHeightMap());
        }
        else {
            RandomMapGenerator.getInstance().createRandomMap(MAP_WIDTH, MAP_HEIGHT);
        }

        heightMap = RandomMapGenerator.getInstance().getHeightMap();
        slopeMap = RandomMapGenerator.getInstance().getSlopeMap();

        for (int x = 0; x < MAP_WIDTH; x++)
            for (int y = 0; y < MAP_WIDTH; y++) {
                Object newTile = Instantiate(Resources.Load("EmptyTile"));
                GameObject newTileGO = (GameObject)newTile;
                tileObjects[x, y] = newTileGO;
                float zIndex = (x + y) * Z_PER_TILE;
                newTileGO.GetComponent<TileScript>().setIndex(x, y);
                newTileGO.GetComponent<TileScript>().setTileHeight(heightMap[x,y]* GRID_DEPTH);
                newTileGO.GetComponent<TileScript>().setPosition((x - y) * GRID_WIDTH, (x + y) * GRID_HEIGHT, zIndex);
                newTileGO.GetComponent<TileScript>().addItem(TileItemProperties.getItemDataByName("grass" + ((int)(slopeMap[x, y])).ToString()));
                newTileGO.transform.parent = GameObject.Find("TileContainer").transform;

            }

        if (loadedData != null) {
            loadTiles();
        }

        StartCoroutine("Save");
    }

    public void loadGameData() {
        if (File.Exists(SAVE_FILE_PATH) == false) return;
        string saveDataString = File.ReadAllText(SAVE_FILE_PATH);
        loadedData = JsonUtility.FromJson<SaveData>(saveDataString);
    }

    public void loadTiles() {
        TileSaveData[] tileSaveDatas = loadedData.tileSaveDatas;
        for (int i = 0; i < tileSaveDatas.Length; i++) {
            TileSaveData currentTile = tileSaveDatas[i];
            for (int j = 0; j < currentTile.tileItemSaveDatas.Length; j++) {
                TileItemSaveData currentTileItem = currentTile.tileItemSaveDatas[j];
                if (currentTileItem.tileItemDataName != TileItemProperties.grass0.name) {
                    TileItemData itemData = TileItemProperties.getItemDataByName(currentTileItem.tileItemDataName);
                    GameObject addedItem = tileObjects[currentTile.xIndex, currentTile.yIndex].GetComponent<TileScript>().addItem(itemData);
                    if (addedItem != null) {
                        addedItem.GetComponent<TileItemScript>().setSpriteIndex(currentTileItem.currentSpriteIndex);
                    }
                }
            }
        }
    }

    IEnumerator Save() {
        while (true) {
            yield return new WaitForSeconds(5);
            SaveData saveData = new SaveData(tileObjects, heightMap);
            string saveDataString = JsonUtility.ToJson(saveData);

            File.WriteAllText(SAVE_FILE_PATH, saveDataString);
        }
    }

    public static GameObject[,] getGetTileObjects() {
        return tileObjects;
    }
    public static int[,] getGetHeightMap() {
        return heightMap;
    }
    public static SlopeDirections[,] getSlopeMap() {
        return slopeMap;
    }

    void Update() {

    }

}
