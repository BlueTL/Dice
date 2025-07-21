using UnityEngine;

public class CyberWall : MonoBehaviour
{
    public int hp = 100;

    // 🔒 Stun status
    public bool isStunned = false;
    public int stunTurnsLeft = 0;

    public void StartTurn()
    {
        // ถ้าโดนสตัน
        if (isStunned)
        {
            stunTurnsLeft--;

            Debug.Log(name + " is stunned and cannot act!");

            if (stunTurnsLeft <= 0)
            {
                isStunned = false;
                Debug.Log(name + " is no longer stunned.");
            }

            return; // ข้ามการกระทำในเทิร์นนี้
        }

        Debug.Log(name + " started turn normally.");
        // ทำอย่างอื่นได้ เช่น โจมตี หรือรอคำสั่ง
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(name + " takes " + damage + " damage! HP = " + hp);
    }

    // 💥 ใช้สกิลสตัน
    public void UseStunSkill(PlayerUnit target)
    {
        target.isStunned = true;
        target.stunTurnsLeft = 1;
        Debug.Log(name + " used Stun on " + target.name + "!");
    }
}