using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointMarker : MonoBehaviour
{
   public Image img;
   // public Transform target;
   public Vector3 offset = new Vector3(0, 40, 0);


   // Update is called once per frame
   void Update()
   {
      float minX = img.GetPixelAdjustedRect().width / 2;
      float maxX = Screen.width - minX;
      float minY = img.GetPixelAdjustedRect().height / 2;
      float maxY = Screen.width - minY;

      //Keep marker On Screen
      Vector2 pos = Camera.main.WorldToScreenPoint(transform.position) + offset;

      pos.x = Mathf.Clamp(pos.x, minX, maxX);
      pos.y = Mathf.Clamp(pos.y, minY, maxY);



      img.transform.position = pos;
   }
}
