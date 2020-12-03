using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadTransition : MonoBehaviour
{
   private bool trigger = false;
   public Animator transition;
   public TeleportToWorld tp;
   private int levelOffset = 0;

   // Update is called once per frame
   void Update()
   {
      if (trigger)
      {
         LoadNextLevel();
      }
   }

   public void LoadNextLevel()
   {
      StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1 + levelOffset));
   }

   public void ActivateLoadTrigger()
   {
      trigger = true;
      Debug.Log("Loading " + tp.level);
      if (tp)
      {
         levelOffset = tp.level - 1;
      }
   }

   IEnumerator LoadLevel(int levelIndex)
   {
      transition.SetTrigger("Start");

      yield return new WaitForSeconds(2);

      SceneManager.LoadScene(levelIndex);
   }
}
