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

    public void BoxDestroyPlay(Transform objectTransform)
    {
        RuntimeManager.PlayOneShot(boxDestroyAudio, objectTransform.position);
    }

    public void SwitchPlay(Transform objectTransform)
    {
        RuntimeManager.PlayOneShot(switchAudio, objectTransform.position);
    }
}
