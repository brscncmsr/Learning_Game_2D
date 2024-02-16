using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [HideInInspector] public GameObject sounds;
    [HideInInspector] public List<AudioSource> list = new List<AudioSource>();
    public GameSounds c1h;
    public GameSounds c1g;
    public GameSounds c1s1;
    public GameSounds c1s2;
    public GameSounds c2h;
    public GameSounds c2g;
    public GameSounds c2s;
    public GameSounds c1su;
    public GameSounds c2su;
    public GameSounds h1;
    public GameSounds h2;
    public GameSounds h3;
    public GameSounds h4;
    [System.Serializable]
    public class GameSounds
    {
        [HideInInspector] public AudioSource player;
        public AudioClip clip;

        private void SetPlayer()
        {
            player = Instance.sounds.AddComponent<AudioSource>();
            Instance.list.Add(player);
            player.playOnAwake = false;
            player.clip = clip;
        }
        public void PlaySound()
        {
            StopAllSound();
            if (player == null)
            {
                SetPlayer();
            }
            player.Play();
        }
        private void StopAllSound()
        {
            for (int i = 0; i < Instance.list.Count; i++)
            {
                Instance.list[i].Stop();
            }
        }
    }
    private void Awake()
    {
        Instance = this;
        sounds = gameObject;
    }
}
