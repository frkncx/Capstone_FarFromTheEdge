using UnityEngine;

public enum QuestState
{
    NotStarted,
    InProgress,
    Completed
}

[System.Serializable]
public class Quest
{
    public QuestState state = QuestState.NotStarted;
}