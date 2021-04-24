using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;
    public void Increment(Vector3 number)
    {
        value += number;
    }

    public void SetValue(Vector3 number)
    {
        value = number;
    }
}
