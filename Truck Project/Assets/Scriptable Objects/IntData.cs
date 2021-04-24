using UnityEngine;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value;
    public void Increment(int number)
    {
        value += number;
    }

    public void SetValue(int number)
    {
        value = number;
    }
}
