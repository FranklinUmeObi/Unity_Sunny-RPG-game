using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
   public bool isInRange = false;
   public UnityEvent action;
   public UnityEvent action2;

   // Start is called before the first frame update
   void Start()
   {
   }

   // Update is called once per frame
   void Update()
   {
      if (isInRange)
      {
         action.Invoke();
      }
   }

   private void OnTriggerEnter(Collider collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         isInRange = true;
      }
   }

   private void OnTriggerExit(Collider collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         isInRange = false;
         action2.Invoke();
      }
   }
}
