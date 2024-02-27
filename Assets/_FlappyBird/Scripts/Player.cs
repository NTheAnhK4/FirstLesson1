using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody2D rb;
    private float jumpForce = 10f;
    public float cooldown;
    public float timeshoot = 0.5f;
    public float boundTop = 9.5f;
    public float boundDown = -9.5f;
       private void Start()
       {
          rb = GetComponent<Rigidbody2D>();
          cooldown = timeshoot;
         
       }
    
       private void Update()
       {
          
          if (Input.GetMouseButtonDown(0))
          {
             
             rb.velocity = new Vector2(0, jumpForce);

             
          }
          CtrlPos();
          cooldown -= Time.deltaTime;
          if (cooldown <= 0.0f)
          {
             Shoot();
             cooldown = timeshoot;
          }

       }

       void Shoot()
       {
          PoolingManager.Instance.GetObject(NamePrefabPool.Bullet,null,transform.position).Disable(4);
       }
       private void OnCollisionEnter2D(Collision2D other)
       {
          if (other.gameObject.CompareTag("Block"))
          {
             Debug.Log("Colider with Block");
          }
       }

       protected void CtrlPos()
       {
          Vector2 pos = transform.position;
          if (pos.y >= boundTop) transform.position = new Vector2(pos.x, boundTop);
          if(pos.y <= boundDown) transform.position = new Vector2(pos.x, boundDown);
       }
}
