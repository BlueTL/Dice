using UnityEngine;

public class AttackOnClick : MonoBehaviour
{
    public int hp = 100;
    public string playerTag;

    private void OnMouseDown()
    {
        if (TurnManager.Instance.CanAttackThis(playerTag))
        {
            TakeDamage(10);
            TurnManager.Instance.EndTurn();
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(gameObject.name + " ถูกโจมตี เหลือ HP: " + hp);

        if (hp <= 0)
        {
            Debug.Log(gameObject.name + " พ่ายแพ้แล้ว!");
            Destroy(gameObject);
        }
    }
}