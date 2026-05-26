using UnityEngine;
using FMODUnity;
using ArtNotes.PhysicalInteraction;

public class PianoInteraction : InteractableObject
{
    [Header("FMOD")]
    [SerializeField] private EventReference pianoEvent; 

    [Header("Debug")]
    [SerializeField] private bool logOnInteract = false;

    
    public override void InteractStart(RaycastHit hit)
    {
      

        if (pianoEvent.IsNull)
        {
            Debug.LogWarning("[PianoInteraction] No FMOD event assigned!", this);
            return;
        }

        if (logOnInteract)
            Debug.Log("[PianoInteraction] Playing piano FMOD event", this);

        // Play the FMOD event at the piano position 
        RuntimeManager.PlayOneShot(pianoEvent, transform.position);
    }

    
    public override void InteractEnd()
    {
        base.InteractEnd();
        //piano just plays on click.
    }
}
