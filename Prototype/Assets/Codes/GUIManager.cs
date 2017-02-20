using UnityEngine;
using System.Collections;

public class GUIManager{
    public enum TabMode {
        MOUSE,
        BUILDING,
        SPECIAL,
        TERRAIN
    }
    private TabMode currentTabMode;
    private GameObject tabBasic;
    private GameObject tabSpecial;
    private GameObject tabTerrain;
    private static GUIManager instance;

    public GUIManager() {
        Debug.Log("init gui manager");
        tabBasic = GameObject.Find("tabBasic");
        tabSpecial = GameObject.Find("tabSpecial");
        tabTerrain = GameObject.Find("tabTerrain");
        currentTabMode = TabMode.BUILDING;
        if(tabSpecial != null)
        tabSpecial.SetActive(false);
    }

    public  void setTabMode(TabMode tabMode) {
        this.currentTabMode = tabMode;
        tabBasic.SetActive(false);
        tabSpecial.SetActive(false);
        tabTerrain.SetActive(false);

        if (currentTabMode == TabMode.MOUSE) {

        }
        else if (currentTabMode == TabMode.BUILDING) {
            tabBasic.SetActive(true);
        }
        else if (currentTabMode == TabMode.SPECIAL) {
            tabSpecial.SetActive(true);
        }
        else if (currentTabMode == TabMode.TERRAIN) {
            tabTerrain.SetActive(true);
        }

    }

    public TabMode getCurrentTabMode() {
        return currentTabMode;
    }

    public void showPopup(Color color, string text) {
        PopUpScript.getPopup().GetComponent<PopUpScript>().showPopUp(color, text);
    }

    public static GUIManager getInstance() {
        if (instance == null) instance = new GUIManager();
        return instance;
    }
}
