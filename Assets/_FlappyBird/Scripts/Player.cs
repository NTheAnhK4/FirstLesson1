using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 30f;

    private float step = 5f;
    public float cooldown;
    public float timeShoot = 0.5f;
    public Object prefabs;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        //rb.AddForce(new Vector2(0,1000));
        cooldown = timeShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0, jumpForce);
           
        }

        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-step,0 );
        }

        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(step, 0);
        }

        if (Input.GetKey("w"))
        {
            rb.velocity = new Vector2(0,step );
        }

        if (Input.GetKey("s"))
        {
            rb.velocity = new Vector2(0, -step);
        }

        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            //PoolingManager.Instance.GetObject(NamePrefabPool.Bullet, null, transform.position).Disable(2);
            Shoot();
            cooldown = timeShoot;
        }
    }

    public void Shoot()
    {
        PoolingManager.Instance.GetObject(NamePrefabPool.Bullet, null, transform.position).Disable(2);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            //Debug.Log("Collided with Block");
            Instantiate(prefabs, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
    
}
