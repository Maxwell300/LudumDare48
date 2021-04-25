using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static string currentScene;
    public static float timeInAudio = 0f;
    public static bool Timer(ref bool isChanging, ref float timer) {
      if (isChanging)
      {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
          isChanging = false;
        }
      }
      return isChanging;
    }
}
