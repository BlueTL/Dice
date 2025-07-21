using UnityEngine;

public class Buff : MonoBehaviour
{
    public int hp = 100;
    public int baseAttackDamage = 10;

    // 🎯 Buff ดาเมจ
    public bool isBuffed = false;
    public int buffTurnsLeft = 0;
    public int bonusDamage = 0;

    public void StartTurn()
    {
        // เช็กบัฟ
        if (isBuffed)
        {
            buffTurnsLeft--;
            Debug.Log(name + " has damage buff. Turns left: " + buffTurnsLeft);

            if (buffTurnsLeft <= 0)
            {
                isBuffed = false;
                bonusDamage = 0;
                Debug.Log(name + "'s damage buff has ended.");
            }
        }

        Debug.Log(name + " started turn.");
    }

    public void Attack(PlayerUnit target)
    {
        int totalDamage = baseAttackDamage + bonusDamage;
        Debug.Log(name + " attacks " + target.name + " for " + totalDamage + " damage.");
        target.TakeDamage(totalDamage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(name + " takes " + damage + " damage. HP = " + hp);
    }

    // 💪 สกิลบัฟดาเมจให้เพื่อน
    public void UseDamageBuffSkill(PlayerUnit target)
    {
        target.isBuffed = true;
        target.buffTurnsLeft = 3;
        target.bonusDamage = 10;

        Debug.Log(name + " used Damage Buff on " + target.name + "! (+10 damage for 3 turns)");
    }
}