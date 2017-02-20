using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager {

    static ResourceManager instance;

    Sprite[] sprites;
    Dictionary<string, Sprite> spritesByName = new Dictionary<string, Sprite>();

    public ResourceManager(){
        sprites = Resources.LoadAll<Sprite>("");
        for(int i = 0; i < sprites.Length; i++){
            spritesByName[sprites[i].name] = sprites[i];
        }
    }

    public Sprite getSprite(string spriteName){
        return spritesByName[spriteName];
    }


    public static ResourceManager getInstance() {
        if (instance == null) instance = new ResourceManager();
        return instance;
    }
}
