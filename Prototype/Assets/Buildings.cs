using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buildings : Singleton<Buildings> {

    public List<Building> list = new List<Building>();

    protected Buildings() {
        loadImage();
    }

    private void loadImage()
    {
        #region electricity

        // wind turbine
        Sprite windTurbineSpr = Resources.Load<Sprite>("buildings/eolien.png");
        string windTurbineDesc = "Create electricity with the force of the wind!";
        list.Add(new Building("wind turbine", windTurbineDesc, 10, 0, 10, 0, 0, 500, windTurbineSpr));

        Sprite coalFiredPlantSpr = Resources.Load<Sprite>("buildings/CoaslFiredPlant.png");
        string charcoalFiredPlantDesc = "It brings more energy for less money, but generate pollution";
        list.Add(new Building("charcoal fired plant", charcoalFiredPlantDesc, 20, 0, 0, 10, 0, 100, coalFiredPlantSpr));

        #endregion

        #region water

        Sprite waterPlant = Resources.Load<Sprite>("buildings/walterPlant.png");
        string waterPlantDesc = "If you need a drink, take this !";
        list.Add(new Building("water plant", waterPlantDesc, 0, 50, 0, 0, 0, 300, coalFiredPlantSpr));

        #endregion

        #region population

        Sprite houseSpr = Resources.Load<Sprite>("buildings/house.png");
        string houseDesc = "It brings population (money $$$)";
        list.Add(new Building("house", houseDesc, 0, 0, 0, 0, 10, 100, houseSpr));

        #endregion
    }
    // eolien


    //();

}
