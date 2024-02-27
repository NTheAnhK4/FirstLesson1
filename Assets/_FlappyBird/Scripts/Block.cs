
using System;
using GameTool;
using UnityEngine;


public class Block : BasePooling
{
    private float curHp;
    public BlockType blockType;
    public SpriteRenderer sr;
    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        Disable(10f);
    }

    public void SetData()
    {
        curHp = GameData.Instance.blockData.listBlockSprite[(int)blockType].spriteInfos.maxHp;
        sr.sprite = GameData.Instance.blockData.listBlockSprite[(int)blockType].spriteInfos.listSprite[2];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            curHp -= 1;
            if(curHp <= 0) Destroy(gameObject);
        }
    }
}
