using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    List<AudioSource> audioSources = new List<AudioSource>();
    Dictionary<string, AudioClip> ClipMap = new Dictionary<string, AudioClip>();
    public void Init()
    {
        var root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject("@Sound");
            Object.DontDestroyOnLoad(root);

            var Names = System.Enum.GetNames(typeof(Define.Sound));
            for (int i = 0; i < (int)Define.Sound.MaxCount; i++)
            {
                var go = new GameObject(Names[i]);
                audioSources.Add(go.AddComponent<AudioSource>());
                go.transform.parent = root.transform;
            }
        }

        audioSources[(int)Define.Sound.BGM].loop = true;
    }

    public void Clear()
    {
        audioSources.Clear();
        ClipMap.Clear();
    }

    public void play(Define.Sound type, string path, float pitch = 1f)
    {
        if (!path.Contains("Sounds/")) path = $"Sounds/{path}";
        var clip = GetAddClip(path);
        play(type, clip, pitch);
    }

    public void play(Define.Sound type, AudioClip clip, float pitch = 1f)
    {
        if (clip == null) return;
        var source = audioSources[(int)type];
        source.pitch = pitch;
        source.clip = clip;

        switch (type)
        {
            case Define.Sound.BGM:
                if (source.isPlaying)
                    source.Stop();
                source.Play();
                break;
            case Define.Sound.Effect:
                source.PlayOneShot(clip);
                break;
        }
    }

    AudioClip GetAddClip(string path)
    {
        AudioClip clip = null;
        if (!ClipMap.TryGetValue(path, out clip))
        {
            clip = Manager.Instance.resourceManager.Load<AudioClip>(path);
            if (clip == null)
            {
                Debug.Log($"오디오클립 널 => {path}");
                return null;
            }
            ClipMap.Add(path, clip);
        }
        return clip;
    }

}
