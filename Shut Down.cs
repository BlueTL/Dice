using UnityEngine;

public class Admin : MonoBehaviour
{
    public int hp = 100;
    public bool isDead = false;

    public void StartTurn()
    {
        if (isDead)
        {
            Debug.Log(name + " is dead. Cannot take a turn.");
            return;
        }

        Debug.Log(name + " started turn.");
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        hp -= damage;
        Debug.Log(name + " takes " + damage + " damage! HP = " + hp);

        if (hp <= 0)
        {
            isDead = true;
            Debug.Log(name + " has died.");
        }
    }

    // 💀 Turn Kill Skill (1/500 chance)
    public void UseTurnKillSkill(PlayerUnit target)
    {
        if (target.isDead)
        {
            Debug.Log(target.name + " is already dead.");
            return;
        }

        int roll = Random.Range(1, 501); // 1 to 500
        if (roll == 1)
        {
            target.hp = 0;
            target.isDead = true;
            Debug.Log(name + " used Turn Kill! " + target.name + " is instantly killed!");
        }
        else
        {
            Debug.Log(name + " tried Turn Kill but failed. (Rolled: " + roll + ")");
        }
    }
}