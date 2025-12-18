using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogueData", menuName = "NewDialogueData")]
[System.Serializable]
public class NewDialogueData : ScriptableObject
{
    public string charName;
    public string[] dialogueLines;
}
