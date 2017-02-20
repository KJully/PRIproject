using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour{

    TileItemData selectedTileItem = TileItemProperties.base1;

    private readonly int KEYBOARD_SPEED = 1;
    private readonly float DRAG_SPEED = 0.02f;
    private readonly float MIN_FOV = 1f;
    private readonly float MAX_FOV = 20f;
    private readonly float FOV_CHANGE_SPEED = 2f;

    private readonly Color GHOST_RED = new Color(1.0f, 0.3f, 0.3f, 0.7f);
    private readonly Color GHOST_GREEN = new Color(0.3f, 1.0f, 0.3f, 0.7f);

    private Vector3 dragOrigin;
    private static GameObject ghostTile;
    private int leftMouseHold = 0;



    public TileScript raycast (Vector2 mousePosition) {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        RaycastHit2D[] hit = Physics2D.RaycastAll(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0f);
        if (hit.Length > 0) {
            GameObject hitObject;
            if (GUIManager.getInstance().getCurrentTabMode() != GUIManager.TabMode.MOUSE) hitObject = hit[hit.Length - 1].collider.gameObject;
            else hitObject = hit[0].collider.gameObject;
            TileItemScript tileItemScript = hitObject.GetComponent<TileItemScript>();
            if (Input.GetMouseButtonDown(0) && GUIManager.getInstance().getCurrentTabMode() == GUIManager.TabMode.MOUSE) tileItemScript.itemClicked();
            TileScript tileScript = tileItemScript.getParentScript();
            return tileScript;
        }
        return null;
    }

    private void updateKeyboard() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(new Vector3(KEYBOARD_SPEED * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(new Vector3(-KEYBOARD_SPEED * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(new Vector3(0, -KEYBOARD_SPEED * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(new Vector3(0, KEYBOARD_SPEED * Time.deltaTime, 0));
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            selectedTileItem = TileItemProperties.speciall;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            selectedTileItem = TileItemProperties.base2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            selectedTileItem = TileItemProperties.base3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            selectedTileItem = TileItemProperties.base4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            selectedTileItem = TileItemProperties.base5;
        }
    }

    private void updateMouse() {
        float fov = Camera.main.orthographicSize;
        fov += Input.GetAxis("Mouse ScrollWheel") * FOV_CHANGE_SPEED;
        fov = Mathf.Clamp(fov, MIN_FOV, MAX_FOV);
        Camera.main.orthographicSize = fov;

        //TODO: RAYCAST FOR BETTER CAMERA CONTROL SPEED

        if (Input.GetMouseButtonUp(0)) {
            leftMouseHold = 0;
        }
        if (Input.GetMouseButton(0)) {
            leftMouseHold++;
        }

        if (Input.GetMouseButtonDown(1)) {
            GUIManager.getInstance().setTabMode(GUIManager.TabMode.MOUSE);
            ghostTile.SetActive(false);
        }

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)) {
            dragOrigin = Input.mousePosition;
            return;
        }
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1)) return;

        Vector3 delta = Input.mousePosition - dragOrigin;
        transform.Translate(-delta * DRAG_SPEED);
        dragOrigin = Input.mousePosition;
    }

    public void guiItemClicked(GameObject gameObject) {
        Debug.Log(gameObject.name);
        if (gameObject.name == "tabButtonBasic") {
            GUIManager.getInstance().setTabMode(GUIManager.TabMode.BUILDING);
            ghostTile.SetActive(true);
        }
        else if (gameObject.name == "tabButtonSpecial") {
            GUIManager.getInstance().setTabMode(GUIManager.TabMode.SPECIAL);
            ghostTile.SetActive(true);
        }
        else if (gameObject.name == "tabButtonTerrain") {
            GUIManager.getInstance().setTabMode(GUIManager.TabMode.TERRAIN);
            ghostTile.SetActive(true);
        }
        else if (gameObject.name == "mouse") {
            GUIManager.getInstance().setTabMode(GUIManager.TabMode.MOUSE);
            ghostTile.SetActive(false);
        }
        else {
            TileItemData clickedItemData = TileItemProperties.getItemDataByName(gameObject.name);
            if (clickedItemData != null) {
                setSelectedTileItem(clickedItemData);
            }
        }
    }

    public void setSelectedTileItem(TileItemData selectedItem) {
        selectedTileItem = selectedItem;
        if (selectedItem == null) return;
        if(ghostTile != null)Destroy(ghostTile);
        ghostTile = TileItemFactory.getInstance().createTileItem(selectedItem, null);
        ghostTile.GetComponent<TileItemScript>().setUseCollider(false);
        ghostTile.GetComponent<TileItemScript>().setSpriteIndex(0);
    }

    int lastRaycastIndexX = 0;
    int lastRaycastIndexY = 0;
    int lastGhostGridSize = 0;
    void updateGhostTile(TileScript raycastedTile) {
        if (raycastedTile == null)return;
        if (GUIManager.getInstance().getCurrentTabMode() == GUIManager.TabMode.MOUSE) return;
        bool addable = ghostTile.GetComponent<TileItemScript>().checkAddable(raycastedTile.GetComponent<TileScript>());
        ghostTile.gameObject.transform.SetParent(raycastedTile.transform);
        ghostTile.gameObject.transform.position = raycastedTile.transform.position;
        ghostTile.gameObject.transform.Translate(0,0,-10f);
       
        SpriteRenderer ghostSprite = ghostTile.GetComponentInChildren<SpriteRenderer>();
        if(ghostSprite != null)
            ghostSprite.color = addable ? GHOST_GREEN : GHOST_RED;

        lastRaycastIndexX = raycastedTile.getIndexX();
        lastRaycastIndexY = raycastedTile.getIndexY();
        lastGhostGridSize = selectedTileItem.gridSize;

    }

    void Start() {
        setSelectedTileItem(TileItemProperties.base1);
        GUIManager.getInstance();

    }

    void Update() {
        updateKeyboard();
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() == true) return;
        TileScript raycastedTile = raycast(Input.mousePosition);
        updateGhostTile(raycastedTile);
        if (Input.GetMouseButtonUp(0)) {
            if (raycastedTile == null) return;
            if(GUIManager.getInstance().getCurrentTabMode() != GUIManager.TabMode.MOUSE && leftMouseHold < 10)
                raycastedTile.addItem(selectedTileItem); 
        }
        updateMouse();
    }
}
