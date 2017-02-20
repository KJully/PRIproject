using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomMapGenerator {
    /*
     * https://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise.html
     */
    private static RandomMapGenerator instance;
    private int width = 0;
    private int height = 0;
    private float scale = 1;
    private float xOrg = 0;
    private float yOrg = 0;
    private int[,] heightMap;
    private SlopeDirections[,] slopeMap;

    private RandomMapGenerator() {

    }

    private void generateHeightMap() {
        float y = 0.0F;
        while (y < height) {
            float x = 0.0F;
            while (x < width) {
                float xCoord = xOrg + x / width * scale;
                float yCoord = yOrg + y / height * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                heightMap[(int)x, (int)y] = (int)(10 * sample);       //Between 0 and 5
                x++;
            }
            y++;
        }

    }

    private int compareHeight(int x, int y, int dx, int dy, int[,] map) {
        if (x + dx + 1 > width) return 0;
        if (x + dx < 0) return 0;
        if (y + dy + 1 > height) return 0;
        if (y + dy < 0) return 0;
        return map[x, y].CompareTo(map[x + dx, y + dy]);
    }

    private void calculateSlopeDirections() {
        Dictionary<string, SlopeDirections> slopeDictionary = new Dictionary<string, SlopeDirections>();
        slopeDictionary["N"] = SlopeDirections.NORTH;
        slopeDictionary["S"] = SlopeDirections.SOUTH;
        slopeDictionary["E"] = SlopeDirections.EAST;
        slopeDictionary["W"] = SlopeDirections.WEST;

        slopeDictionary["NE"] = SlopeDirections.NORTH_EAST;
        slopeDictionary["NW"] = SlopeDirections.NORTH_WEST;
        slopeDictionary["SE"] = SlopeDirections.SOUTH_EAST;
        slopeDictionary["SW"] = SlopeDirections.SOUTH_WEST;

        slopeMap = new SlopeDirections[width, height];
        int[,] heightCopy = (int[,])heightMap.Clone();
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++) {
                //if (i == 0 || j == 0 || i > width - 2 || j > height - 2) { slopeMap[i, j] = SlopeDirections.NO_SLOPE; continue; }
                int currentHeight = heightCopy[i, j];
                string slopeDirection = "";

                if (compareHeight(i, j, 1, 0, heightCopy) == -1) { slopeDirection += "N"; }
                if (compareHeight(i, j, -1, 0, heightCopy) == -1) { slopeDirection += "S"; }
                if (compareHeight(i, j, 0, 1, heightCopy) == -1) { slopeDirection += "W"; }
                if (compareHeight(i, j, 0, -1, heightCopy) == -1) { slopeDirection += "E"; }


                if (slopeDirection.Length == 1) {
                    slopeMap[i, j] = slopeDictionary[slopeDirection];
                    continue;
                }

                if (slopeDirection.Length >= 2) { // NO TEXTUREs THIS KIND OF DIRECTION :(
                    if (slopeDirection.Contains("S"))
                        slopeMap[i, j] = SlopeDirections.SOUTH;
                    if (slopeDirection.Contains("E"))
                        slopeMap[i, j] = SlopeDirections.EAST;
                    if (slopeDirection.Contains("W"))
                        slopeMap[i, j] = SlopeDirections.WEST;
                    if (slopeDirection.Contains("N"))
                        slopeMap[i, j] = SlopeDirections.NORTH;
                    continue;
                }

                if (compareHeight(i, j, -1, -1, heightCopy) == -1) { slopeDirection += "SE"; }
                if (compareHeight(i, j, -1, 1, heightCopy) == -1) { slopeDirection += "SW"; }
                if (compareHeight(i, j, 1, -1, heightCopy) == -1) { slopeDirection += "NE"; }
                if (compareHeight(i, j, 1, 1, heightCopy) == -1) { slopeDirection += "NW"; }
                                                                                                               
                if (slopeDirection.Length == 2) {
                    slopeMap[i, j] = slopeDictionary[slopeDirection];
                    continue;
                }

                //slopeMap[i, j] = SlopeDirections.NO_SLOPE;
            }
    }

    public void createRandomMap(int width, int height) {
        this.width = width;
        this.height = height;
        heightMap = new int[width, height];
        generateHeightMap();
        calculateSlopeDirections();
    }

    public void loadHeightMap(int[,] heightMap) {
        this.width = heightMap.GetLength(0);
        this.height = heightMap.GetLength(1);
        this.heightMap = heightMap;
        calculateSlopeDirections();
    }

    public int[,] getHeightMap() {
        return heightMap;
    }

    public SlopeDirections[,] getSlopeMap() {
        return slopeMap;
    }

    public static RandomMapGenerator getInstance() {
        if (instance == null) instance = new RandomMapGenerator();
        return instance;
    }
}
