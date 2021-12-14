using System.Collections;
using UnityEngine;

public static class SettingSaver
{
   public static float musicVolume;
   public static float SFXVolume;
   public static float FOVvalue;
   public static float mouseValue;

   static SettingSaver() {
       musicVolume = 0;
       SFXVolume = 0;
       FOVvalue = 69;
       mouseValue = 500;
   }
}
