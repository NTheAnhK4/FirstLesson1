using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BackGroundMove : MonoBehaviour
{
   [SerializeField] private float speed = 10f;
   private float size = 18;
   [SerializeField] protected Vector3 curPos;

   private void Start()
   {
     
      curPos = transform.position;
   }

   private void Update()
   {
      if (transform.position.x + 2 * size <= curPos.x)
      {
        
         transform.position = new Vector3(curPos.x + size, curPos.y, curPos.z);
      }
      transform.Translate(Vector3.left*Time.deltaTime*speed);
   }
}
