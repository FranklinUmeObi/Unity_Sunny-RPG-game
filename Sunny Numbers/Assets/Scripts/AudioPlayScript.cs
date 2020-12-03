using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayScript : MonoBehaviour
{
   private AudioSource audioSource;
   private bool isMuted = false;
   void Start()
   {
      audioSource         = GetComponent<AudioSource>();
      isMuted             = PlayerPrefs.GetInt("MUTED") == 1;
      AudioListener.pause = isMuted;
   }

   public void MutePressed()
   {
      isMuted             = !isMuted;
      AudioListener.pause = isMuted;
      PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
   }
}
