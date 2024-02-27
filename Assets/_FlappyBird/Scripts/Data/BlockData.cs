using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block Data", menuName = "Data/Block Data")]
public class BlockData : ScriptableObject
{
    public List<BlockSprite> listBlockSprite;
}
// them ra man hinh

[Serializable]
public class BlockSprite
{
    //id
    public BlockType blockType;

    //anim
    public SpriteInfos spriteInfos;
}

[Serializable]
public class SpriteInfos
{
    public List<Sprite> listSprite;
    public float maxHp;
}

public enum BlockType
{
    Wood = 0,
    Stone = 1,
    Metal = 2,
}