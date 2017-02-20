using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileItemProperties {

    //TODO Load tile properties from file


    public static Dictionary<string, TileItemData> properties = new Dictionary<string, TileItemData>();

    public static TileItemData grass0 = createItemData(TileItemType.GRASS, TileItemType.NOTHING, 0, new string[] { "green0" }, "grass0");
    public static TileItemData grass1 = createItemData(TileItemType.GRASS, TileItemType.NOTHING, 0, new string[] { "green1" }, "grass1");
    public static TileItemData grass2 = createItemData(TileItemType.GRASS, TileItemType.NOTHING, 0, new string[] { "green2" }, "grass2");
    public static TileItemData grass3 = createItemData(TileItemType.GRASS, TileItemType.NOTHING, 0, new string[] { "green3" }, "grass3");
    public static TileItemData grass4 = createItemData(TileItemType.GRASS, TileItemType.NOTHING, 0, new string[] { "green4" }, "grass4");
    public static TileItemData grass5 = createItemData(TileItemType.GRASS, TileItemType.NOTHING, 0, new string[] { "green5" }, "grass5");
    public static TileItemData grass6 = createItemData(TileItemType.GRASS, TileItemType.NOTHING, 0, new string[] { "green6" }, "grass6");
    public static TileItemData grass7 = createItemData(TileItemType.GRASS, TileItemType.NOTHING, 0, new string[] { "green7" }, "grass7");
    public static TileItemData grass8 = createItemData(TileItemType.GRASS, TileItemType.NOTHING, 0, new string[] { "green8" }, "grass8");

    public static TileItemData base1 = createBaseItemData(new string[] { "base1", "base2", "base4", "base3" }, "base1");
    public static TileItemData base2 = createBaseItemData(new string[] { "base5", "base6", "base7", "base8" }, "base2");
    public static TileItemData base3 = createBaseItemData(new string[] { "base9", "base10", "base11", "base12" }, "base3");
    public static TileItemData base4 = createBaseItemData(new string[] { "base13", "base14", "base15", "base16" }, "base4");
    public static TileItemData base5 = createBaseItemData(new string[] { "base17", "base18", "base19", "base20" }, "base5");
    public static TileItemData base6 = createBaseItemData(new string[] { "base21", "base22", "base23", "base24" }, "base6");
    public static TileItemData base7 = createBaseItemData(new string[] { "base25", "base26", "base27", "base28" }, "base7");

    public static TileItemData road = createRoadItemData(new string[] { "road0000","road0001","road0010","road0011","road0100",
        "road0101","road0110","road0111","road1000","road1001","road1010","road1011","road1100","road1101","road1110","road1111",
        "roadSlope1", "roadSlope2", "roadSlope3", "roadSlope4"}, "road");

    public static TileItemData water = createWaterItemData(new string[] { "water0000","water0001","water0010","water0011","water0100",
        "water0101","water0110","water0111","water1000","water1001","water1010","water1011","water1100","water1101","water1110","water1111",
        "waterSlope1", "waterSlope2", "waterSlope3", "waterSlope4"}, "water");

    public static TileItemData appartment1 = createAppartmentItemData( new string[] { "appartment1", "appartment2" }, "appartment1");
    public static TileItemData appartment2 = createAppartmentItemData( new string[] { "appartment3", "appartment4" }, "appartment2");
    public static TileItemData appartment3 = createAppartmentItemData( new string[] { "appartment5", "appartment6" }, "appartment3");
    public static TileItemData appartment4 = createAppartmentItemData( new string[] { "appartment7", "appartment8" }, "appartment4");
    public static TileItemData appartment5 = createAppartmentItemData( new string[] { "appartment9", "appartment10" }, "appartment5");
    public static TileItemData appartment6 = createAppartmentItemData( new string[] { "appartment11", "appartment12" }, "appartment6");

    public static TileItemData roof1 = createRoofItemData( new string[] { "roof1", "roof2", "roof3", "roof4" }, "roof1");
    public static TileItemData roof2 = createRoofItemData( new string[] { "roof5", "roof6", "roof7", "roof8" }, "roof2");
    public static TileItemData roof3 = createRoofItemData( new string[] { "roof9", "roof10", "roof11", "roof12" }, "roof3");
    public static TileItemData roof4 = createRoofItemData( new string[] { "roof13", "roof14", "roof15", "roof16" }, "roof4");
    public static TileItemData roof5 = createRoofItemData( new string[] { "roof17", "roof18", "roof19", "roof20" }, "roof5");

    public static TileItemData speciall = createSpecialItemData( new string[] { "sp_aqua" },        "sp_aqua",          new Color(0.2f, 0.8f, 0.8f), "Special Building Text 1");
    public static TileItemData special2 = createSpecialItemData( new string[] { "sp_blue" },        "sp_blue",          new Color(0.2f, 0.2f, 0.8f), "Special Building Text 2");
    public static TileItemData special3 = createSpecialItemData( new string[] { "sp_green" },       "sp_green",         new Color(0.2f, 0.8f, 0.2f), "Special Building Text 3");
    public static TileItemData special4 = createSpecialItemData( new string[] { "sp_lightblue" },   "sp_lightblue",     new Color(0.2f, 0.8f, 0.8f), "Special Building Text 4");
    public static TileItemData special5 = createSpecialItemData( new string[] { "sp_orange" },      "sp_orange",        new Color(0.8f, 0.5f, 0.2f), "Special Building Text 5");
    public static TileItemData special6 = createSpecialItemData( new string[] { "sp_pink" },        "sp_pink",          new Color(0.8f, 0.5f, 0.5f), "Special Building Text 6");
    public static TileItemData special7 = createSpecialItemData( new string[] { "sp_purple" },      "sp_purple",        new Color(0.8f, 0.2f, 0.8f), "Special Building Text 7");
    public static TileItemData special8 = createSpecialItemData( new string[] { "sp_red" },         "sp_red",           new Color(0.8f, 0.2f, 0.2f), "Special Building Text 8");
    public static TileItemData special9 = createSpecialItemData( new string[] { "sp_yellow" },      "sp_yellow",        new Color(0.8f, 0.8f, 0.2f), "Special Building Text 9");

    public static TileItemData specia10 = createSpecialItemData( new string[] { "park_aqua" },      "park_aqua",        new Color(0.2f, 1.0f, 0.8f), "Special Park Text 1");
    public static TileItemData specia11 = createSpecialItemData( new string[] { "park_green" },     "park_green",       new Color(0.2f, 1.0f, 0.2f), "Special Park Text 2");
    public static TileItemData specia12 = createSpecialItemData( new string[] { "park_pink" },      "park_pink",        new Color(0.8f, 0.7f, 0.5f), "Special Park Text 3");
    public static TileItemData specia13 = createSpecialItemData( new string[] { "park_purple" },    "park_purple",      new Color(0.8f, 0.4f, 0.8f), "Special Park Text 4");
    public static TileItemData specia14 = createSpecialItemData( new string[] { "park_red" },       "park_red",         new Color(0.8f, 0.2f, 0.4f), "Special Park Text 5");
    public static TileItemData specia15 = createSpecialItemData( new string[] { "park_yellow" },    "park_yellow",      new Color(0.8f, 1.0f, 0.2f), "Special Park Text 6");

    public static TileItemData createItemData(TileItemType type, TileItemType addableAfter, float itemHeight, string[] sprites, string name, bool singleton = false) {
        TileItemData newItemData = new TileItemData(type, addableAfter, itemHeight, sprites, name, singleton);
        properties.Add(name, newItemData);

        return newItemData;
    }

    public static TileItemData createBaseItemData(string[] sprites, string name) {
        TileItemData newItemData = new TileItemData(TileItemType.BUILDING_BASE, TileItemType.GRASS, 0, sprites, name, false, new Color(0.4f, 0.4f, 0.4f), "Basic Building");
        properties.Add(name, newItemData);

        return newItemData;
    }

    public static TileItemData createSpecialItemData(string[] sprites, string name, Color popupColor, string popUpText) {
        TileItemData newItemData = new TileItemData(TileItemType.SPECIAL, TileItemType.GRASS, 0, sprites, name, true, popupColor, popUpText);
        properties.Add(name, newItemData);

        return newItemData;
    }

    public static TileItemData createRoadItemData(string[] sprites, string name) {
        TileItemData newItemData = new TileItemData(TileItemType.ROAD, TileItemType.GRASS, 0, sprites, name, false);
        properties.Add(name, newItemData);

        return newItemData;
    }

    public static TileItemData createWaterItemData(string[] sprites, string name) {
        TileItemData newItemData = new TileItemData(TileItemType.WATER, TileItemType.GRASS, 0, sprites, name, false);
        properties.Add(name, newItemData);

        return newItemData;
    }

    public static TileItemData createAppartmentItemData(string[] sprites, string name) {
        TileItemData newItemData = new TileItemData(TileItemType.APPARTMENT, TileItemType.BUILDING_BASE, 0, sprites, name, false);
        properties.Add(name, newItemData);

        return newItemData;
    }

    public static TileItemData createRoofItemData(string[] sprites, string name) {
        TileItemData newItemData = new TileItemData(TileItemType.ROOF, TileItemType.APPARTMENT, 0, sprites, name, false);
        properties.Add(name, newItemData);

        return newItemData;
    }

    public static TileItemData getItemDataByName(string name) {
        if (properties.ContainsKey(name)) return properties[name];
        Debug.Log("Couldn't find item data by name: " + name);
        return null;
    }
}
