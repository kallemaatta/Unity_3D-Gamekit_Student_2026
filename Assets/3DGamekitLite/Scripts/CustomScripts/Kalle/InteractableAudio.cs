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

    public EventInstance DoorOpen(EventInstance eventInstance, GameObject obj)
    {
        eventInstance = RuntimeManager.CreateInstance(doorAudio);
        RuntimeManager.AttachInstanceToGameObject(eventInstance, obj, obj.GetComponent<Rigidbody>());
        eventInstance.start();
        return eventInstance;
    }

    public void DoorClose(EventInstance eventInstance)
    {
        eventInstance.keyOff();
        eventInstance.release();
    }
}
