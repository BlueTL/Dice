using UnityEngine;

public class AntiVirus : MonoBehaviour
{
    public int hp = 100;

    // สถานะผิดปกติ
    public bool isPoisoned = false;
    public int poisonTurnsLeft = 0;
    public int poisonDamagePerTurn = 10;

    public bool isStunned = false;
    public int stunTurnsLeft = 0;

    public void StartTurn()
    {
        // ✨ ล้างสถานะอัตโนมัติก่อนทำอย่างอื่น
        AutoCleanse();

        // ตรวจสอบอีกครั้งหลังล้าง (เผื่อยังมีสถานะ)
        if (isStunned)
        {
            stunTurnsLeft--;
            Debug.Log(name + " is stunned and cannot act!");

            if (stunTurnsLeft <= 0)
            {
                isStunned = false;
                Debug.Log(name + " is no longer stunned.");
            }

            return;
        }

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

    // 🧼 ล้างสถานะทันทีเมื่อถึงเทิร์น
    public void AutoCleanse()
    {
        if (isPoisoned || isStunned)
        {
            isPoisoned = false;
            poisonTurnsLeft = 0;

            isStunned = false;
            stunTurnsLeft = 0;

            Debug.Log(name + " cleansed all status effects automatically.");
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(name + " takes " + damage + " damage! HP = " + hp);
    }

    // ใส่สถานะพิษ
    public void ApplyPoison(int turns)
    {
        isPoisoned = true;
        poisonTurnsLeft = turns;
        Debug.Log(name + " is poisoned for " + turns + " turns.");
    }

    // ใส่สถานะสตัน
    public void ApplyStun(int turns)
    {
        isStunned = true;
        stunTurnsLeft = turns;
        Debug.Log(name + " is stunned for " + turns + " turns.");
    }
}