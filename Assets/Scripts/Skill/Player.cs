using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ISkillTarget
{
    public int Health { get; set; } = 100;
    public void ApplyEffect(ISkillEffect effect)
    {
        effect.Apply(this);
    }
}
