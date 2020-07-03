using UnityEngine;

public class OnloadAudio : MonoBehaviour
{
   [SerializeField] private SetAudio _setAudio;

   public int _clip;
   
   private void Awake()
   {
      _setAudio.AudioSetter(_clip);
   }
}
