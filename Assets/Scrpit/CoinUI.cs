using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public SpriteAtlas atlas;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        atlas = Resources.Load<SpriteAtlas>("IngameAtlas");
        image.sprite = atlas.GetSprite("JPY_6x4_10");
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
