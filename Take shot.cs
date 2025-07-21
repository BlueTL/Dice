using UnityEngine;

public class Takeshot : MonoBehaviour
{
    public int hp = 100;
    public bool isDead = false;

    public void StartTurn()
    {
        if (isDead)
        {
            Debug.Log(name + " is dead and cannot take a turn.");
            return;
        }

        Debug.Log(name + " started turn.");
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        hp -= damage;
        Debug.Log(name + " takes " + damage + " damage. HP = " + hp);

        if (hp <= 0)
        {
            isDead = true;
            Debug.Log(name + " has died.");
        }
    }

    // 🗡️ สกิลโจมตีดาเมจ 20 (โอกาสโดน 2 ใน 3)
    public void UseChanceAttackSkill(PlayerUnit target)
    {
        if (target == null || target.isDead) return;

        int roll = Random.Range(0, 3); // 0, 1, 2 → 2/3 โอกาสโดน (1, 2)
        if (roll == 0)
        {
            Debug.Log(name + " used Chance Attack but missed!");
        }
        else
        {
            int damage = 20;
            Debug.Log(name + " used Chance Attack and hit " + target.name + " for " + damage + " damage!");
            target.TakeDamage(damage);
        }
    }
}