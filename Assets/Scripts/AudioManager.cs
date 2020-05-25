using UnityEngine;

// Due to audio latency issues in the Android development platform (as discussed in the Written Report), this script is left largely unused.
public class AudioManager : MonoBehaviour
{
    private static AudioClip hookThrow, ambientNature;
    static AudioSource audioSrc;

    private void Start()
    {
        // Initialise variables
        hookThrow = Resources.Load<AudioClip>("hookThrow");

        ambientNature = Resources.Load<AudioClip>("ambientNature");

        audioSrc = this.GetComponent<AudioSource>();
    }

    // A public function that can be called by other game objects to play sound.
    public void PlaySound(string clipName)
    {
        // Switch statements to play audio based on calls from other game objects.
        switch (clipName)
        {
            case "hookThrow":
                audioSrc.PlayOneShot(hookThrow);
                break;

            case "ambientNature":
                audioSrc.PlayOneShot(ambientNature);
                break;
        }
    }
}
