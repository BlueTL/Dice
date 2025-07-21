using UnityEngine;

public class HidIP : MonoBehaviour
{
    public DiceATK1 Skill1; // ลาก GameObject ที่มี DiceManager มาใส่ใน Inspector

    public bool isInvincible = false;
    public int invincibleTurnsLeft = 0;

    public void UseInvincibleSkill()
    {
        int value = Skill1.diceResult;

        if (value == 2 || value == 4 || value == 6)
        {
            isInvincible = true;
            invincibleTurnsLeft = 1;
            Debug.Log(name + " used Invincible Skill! (Value = " + value + ")");
        }
        else
        {
            Debug.Log(name + " failed to use skill. Value = " + value);
        }
    }
}