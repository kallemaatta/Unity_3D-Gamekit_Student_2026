using UnityEngine;
using FMOD.Studio;
using FMODUnity;

[CreateAssetMenu(fileName = "InteractableAudio", menuName = "Scriptable Objects/InteractableAudio")]
public class InteractableAudio : ScriptableObject
{
    //Declares a EventReference that holds a reference to our specific event
    [SerializeField] private EventReference pickupHealthAudio, boxDestroyAudio, switchAudio, doorAudio;
    
    public void PickUpHealthPlay()
    {
        RuntimeManager.PlayOneShot(pickupHealthAudio);
    }
}
