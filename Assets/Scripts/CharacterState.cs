using UnityEngine;

[CreateAssetMenu(fileName = "CharacterState", menuName = "CharacterState", order = 0)]
public class CharacterState : ScriptableObject
{
    public enum States { Idle, Jumping, Sprint };
    public States activeStates = States.Idle;
}