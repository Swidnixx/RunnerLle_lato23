
using UnityEngine;

public abstract class PowerupSO : ScriptableObject
{
    public bool active;
    public float duration = 10;

    public int level = 1;
    public int upgradeCost = 100;
    public PowerupSO upgraded;
}
