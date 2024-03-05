
using System;
using GameTool;
using UnityEngine;


public class Block : BasePooling
{
    [SerializeField] private float curHp;
    private float maxHP;
    public BlockType blockType;
    public SpriteRenderer sr;
    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        Disable(10f);
    }

    public void SetData()
    {
        maxHP = GameData.Instance.blockData.listBlockSprite[(int)blockType].spriteInfos.maxHp;
        curHp = maxHP;
        sr.sprite = GameData.Instance.blockData.listBlockSprite[(int)blockType].spriteInfos.listSprite[2];
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Bullet"))
    //     {
    //         curHp -= 1;
    //         if(curHp <= 0) Destroy(gameObject);
    //     }
    // }
    public void TakeDamage(float amount)
    {
        curHp -= amount;
        SetSprite();
    }

    public void SetSprite()
    {
        if (curHp / maxHP <= 1f/ 3)
        {
            sr.sprite = GameData.Instance.blockData.listBlockSprite[(int)blockType].spriteInfos.listSprite[0];
        }
        else if (curHp / maxHP <= 2f / 3)
        {
            sr.sprite = GameData.Instance.blockData.listBlockSprite[(int)blockType].spriteInfos.listSprite[1];
        }
        if(curHp == 0) gameObject.SetActive(false);
    }
}
