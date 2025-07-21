using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    public enum Turn { Player1, Player2 }
    public Turn currentTurn = Turn.Player1;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public bool CanAttackThis(string clickedTag)
    {
        return (currentTurn == Turn.Player1 && clickedTag == "Player2") ||
               (currentTurn == Turn.Player2 && clickedTag == "Player1");
    }

    public void EndTurn()
    {
        currentTurn = (currentTurn == Turn.Player1) ? Turn.Player2 : Turn.Player1;
        Debug.Log("เทิร์นของ: " + currentTurn);
    }
}