using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float value;
    public void Increment(float number)
    {
        value += number;
    }

    public void SetValue(float number)
    {
        value = number;
    }
}
