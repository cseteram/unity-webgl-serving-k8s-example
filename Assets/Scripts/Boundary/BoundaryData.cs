using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BoundaryData", order = 1)]
public class BoundaryData : ScriptableObject
{
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
}
