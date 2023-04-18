using UnityEngine;

[CreateAssetMenu(fileName = "MusicScriptableObject", menuName = "ScriptableObjects/Music")]
public class MusicScriptableObject : ScriptableObject
{
    public Sprite albumCover;
    public AudioClip[] playlist;
}
