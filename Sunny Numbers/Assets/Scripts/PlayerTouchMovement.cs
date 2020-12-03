using UnityEngine;

public class PlayerTouchMovement : MonoBehaviour
{
   public Joystick joystick;
   //public Rigidbody player;

   public float moveSpeed   = 10f;
   public float rotateSpeed = 10f;

   float horizontal_Move = 0f;
   float verical_Move    = 0f;
   private Vector3 direction;

   // Update is called once per frame
   void FixedUpdate()
   {
      horizontal_Move = joystick.Horizontal * moveSpeed;
      verical_Move    = joystick.Vertical * moveSpeed;
      direction       = new Vector3(horizontal_Move, GetComponent<Rigidbody>().velocity.y, verical_Move);
      GetComponent<Rigidbody>().velocity = new Vector3(direction.x, direction.y, direction.z);

      if (direction != Vector3.zero)
      {
         transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            rotateSpeed * Time.deltaTime);
      }

      Quaternion q = transform.rotation;
      q.eulerAngles      = new Vector3(0, q.eulerAngles.y, 0);
      transform.rotation = q;
   }
}
