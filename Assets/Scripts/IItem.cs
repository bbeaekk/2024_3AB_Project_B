using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public interface IItem 
{
    string Name { get; }        //이름 
    int ID { get; }             // ID
    void Use();                 //함수
}

public class Weapon : IItem                                 //Item 을 상속 받은 클래스 
{
    public string Name { get; set; }
    public int ID { get; set; }
    public int Damage { get; set; } 

    public Weapon(string name, int id, int damage)          //생성자를 통해 값을 셋팅 한다. 
    {
        Name = name; 
        ID = id; 
        Damage = damage;
    }

    public void Use()
    {
        Debug.Log($"Using wepon {Name} with damage {Damage}");

    }
}

public class HealthPotion : IItem
{
    public string Name { get; set; }
    public int ID { get; set; } 
    public int HealAmount { get; set; }

    public HealthPotion(string name, int iD, int healAmount)
    {
        Name = name;
        ID = iD;
        HealAmount = healAmount;
    }

    public void Use()
    {
        Debug.Log($"Using potion {Name} Healing for {HealAmount}");
    }
}

//제너릭 인벤토리 클래스 
public class Inventory<T> where T : IItem
{
    private List<T> items = new List<T>();
    public void AddItem(T item)
    {
        items.Add(item);
        Debug.Log($"Added {item.Name} to inventory");
    }
    public void UseItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items[index].Use();
        }
        else
        {
            Debug.Log("Invalid item index");
        }
    }
    public void Listitems()
    {
        foreach (var item in items)
        {
            Debug.Log($"Item: {item.Name}, ID : {item.ID}");
        }
    }
}
