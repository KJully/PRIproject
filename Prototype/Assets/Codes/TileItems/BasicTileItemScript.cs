using UnityEngine;
using System.Collections;

public class BasicTileItemScript : TileItemScript {

    public override void itemClicked() {
        base.itemClicked();
        currentSpriteIndex++;
        setSprite(ResourceManager.getInstance().getSprite(tileItemData.sprites[currentSpriteIndex % tileItemData.sprites.Length]));
    }

}
