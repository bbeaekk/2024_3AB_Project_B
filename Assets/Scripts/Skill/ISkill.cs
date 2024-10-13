using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ų Ÿ�� �������̽�
public interface ISkillTarget
{
    void ApplyEffect(ISkillEffect effect);
}

//��ų ȿ�� �������̽�
public interface ISkillEffect
{
    void Apply(ISkillTarget target);
}

public class DamageEffect : ISkillEffect                //Mono�� �ٿ��� ����Ʈ�� �Բ� ��� 
{
    public int Damage { get; set; }

    public DamageEffect (int damage)
    {
        Damage = damage;
    }

    public void Apply(ISkillTarget target)
    {
        if (target is Player player)
        {
            player.Health -= Damage;
            Debug.Log($"Player took {Damage} damage. Remaining health: {player.Health}");
        }
        else if (target is Enemy enemy)
        {
            enemy.Health -= Damage;
            Debug.Log($"Evemy took {Damage} damage. Remaining health: {enemy.Health}");
        }
    }
}

public class HealEffect : ISkillEffect                //Mono�� �ٿ��� ����Ʈ�� �Բ� ��� 
{
    public int HealAmount { get; set; }

    public HealEffect(int damage)
    {
        HealAmount = damage;
    }

    public void Apply(ISkillTarget target)
    {
        if (target is Player player)
        {
            player.Health += HealAmount;
            Debug.Log($"Player healed for {HealAmount} . Remaining health: {player.Health}");
        }
        else if (target is Enemy enemy)
        {
            enemy.Health += HealAmount;
            Debug.Log($"Evemy  healed for {HealAmount} . Remaining health: {enemy.Health}");
        }
    }
}

//���׸� ��ų Ŭ���� 
public class Skill<TTarget, TEffect> where TTarget : ISkillTarget where TEffect : ISkillEffect
{
    public string Name { get; set; }
    public TEffect Effect { get; set; }

    public Skill(string name, TEffect effect)
    {
        Name = name;
        Effect = effect;
    }

    public void Use(TTarget target)
    {
        Debug.Log($"Using skill : {Name}");
        target.ApplyEffect(Effect);
    }
}
