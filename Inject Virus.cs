using UnityEngine;

public class InjectVirus : MonoBehaviour
{
    public int hp = 100;

    public bool isPoisoned = false;
    public int poisonTurnsLeft = 0;
    public int poisonDamagePerTurn = 5;

    public void StartTurn()
    {
        // พิษทำงาน
        if (isPoisoned)
        {
            hp -= poisonDamagePerTurn;
            poisonTurnsLeft--;

            Debug.Log(name + " takes " + poisonDamagePerTurn + " poison damage! HP = " + hp);

            if (poisonTurnsLeft <= 0)
            {
                isPoisoned = false;
                Debug.Log(name + " is no longer poisoned.");
            }
        }

        Debug.Log(name + " started turn.");
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(name + " takes " + damage + " damage! HP = " + hp);
    }

    public void UsePoisonSkill(PlayerUnit target)
    {
        target.isPoisoned = true;
        target.poisonTurnsLeft = 3;
        Debug.Log(name + " used Poison Skill on " + target.name + "!");
    }
}