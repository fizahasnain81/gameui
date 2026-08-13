/*using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager34 : MonoBehaviour
{
    public static AudioManager34 instance;
    private void Awake()
    {
        instance = this;
    }
    public AudioClip sfx_landing,sfx_powerup, sfx_jumping, sfx_key, sfx_frog, sfx_enemypatrol, sfx_door, sfx_enemy, sfx_playermove;
    public AudioClip music_tiktok;
    // Start is called before the first frame update
    public GameObject soundObject;
    public void PlaySFX(string sfxName)
    {
        switch (sfxName)
        {
            case "landing":
                SoundObjectCreation(sfx_landing);
                break;
            case "jumping":
                SoundObjectCreation(sfx_jumping);
                break;
            case "cherry":
                SoundObjectCreation(sfx_powerup);
                break;
            case "patrolenemy":
                SoundObjectCreation(sfx_enemypatrol);
                break;
            case "key":
                SoundObjectCreation(sfx_key);
                break;
            case "frog":
                SoundObjectCreation(sfx_frog);
                break;
            case "door":
                SoundObjectCreation(sfx_door);
                break;
            case "movingenemy":
                SoundObjectCreation(sfx_enemy);
                break;
            case "playermoving":
                SoundObjectCreation(sfx_playermove);
                break;
            default:
                break;
        }
    }
    void SoundObjectCreation(AudioClip clip)
    {
       GameObject newObject= Instantiate(soundObject, transform);
        newObject.GetComponent<AudioSource>().clip = clip;
        newObject.GetComponent<AudioSource>().Play();
    }

     


}
*/

using System.Collections.Generic;
using UnityEngine;

public class AudioManager34 : MonoBehaviour
{
    public static AudioManager34 instance;

    private List<GameObject> activeSoundObjects = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public AudioClip sfx_landing, sfx_powerup, sfx_jumping, sfx_key, sfx_frog, sfx_enemypatrol, sfx_door, sfx_enemy, sfx_playermove;
    public AudioClip music_tiktok;

    public GameObject soundObject;

    // Play SFX based on the name
    public void PlaySFX(string sfxName)
    {
        switch (sfxName)
        {
            case "landing":
                SoundObjectCreation(sfx_landing);
                break;
            case "jumping":
                SoundObjectCreation(sfx_jumping);
                break;
            case "cherry":
                SoundObjectCreation(sfx_powerup);
                break;
            case "patrolenemy":
                SoundObjectCreation(sfx_enemypatrol);
                break;
            case "key":
                SoundObjectCreation(sfx_key);
                break;
            case "frog":
                SoundObjectCreation(sfx_frog);
                break;
            case "door":
                SoundObjectCreation(sfx_door);
                break;
            case "movingenemy":
                SoundObjectCreation(sfx_enemy);
                break;
            case "playermoving":
                SoundObjectCreation(sfx_playermove);
                break;
            default:
                break;
        }
    }

    // Stop SFX based on the name
    public void StopSFX(string sfxName)
    {
        // Stop all sounds that match the given SFX name
        foreach (Transform child in transform)
        {
            AudioSource source = child.GetComponent<AudioSource>();
            if (source != null && source.clip != null && source.clip.name == GetClipByName(sfxName)?.name)
            {
                source.Stop();
                Destroy(child.gameObject); // Cleanup sound object
            }
        }
    }


    private void SoundObjectCreation(AudioClip clip)
    {
        if (clip == null) return;

        GameObject newObject = Instantiate(soundObject, transform);
        AudioSource source = newObject.GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();

        activeSoundObjects.Add(newObject); // Keep track of active sound objects
        Destroy(newObject, clip.length);  // Automatically destroy after sound finishes
    }

    private AudioClip GetClipByName(string name)
    {
        switch (name)
        {
            case "landing": return sfx_landing;
            case "jumping": return sfx_jumping;
            case "cherry": return sfx_powerup;
            case "patrolenemy": return sfx_enemypatrol;
            case "key": return sfx_key;
            case "frog": return sfx_frog;
            case "door": return sfx_door;
            case "movingenemy": return sfx_enemy;
            case "playermoving": return sfx_playermove;
            default: return null;
        }
    }

    public void PlayMusic(string musicName)
    {
        switch (musicName)
        {
            case "tiktok":
                SoundObjectCreation(music_tiktok);
                break;
            default:
                break;
        }
    }
    void MusiObjectCreation(AudioClip clip)
    {
        GameObject newObject = Instantiate(soundObject, transform);
        newObject.GetComponent<AudioSource>().clip = clip;
        newObject.GetComponent<AudioSource>().loop = true;
        newObject.GetComponent<AudioSource>().Play();
    }


}
