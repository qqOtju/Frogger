using UnityEngine;

public class FrogSpawner : MonoBehaviour
{
    [SerializeField] private GameStatusEvent onGameStatusChange;
    [SerializeField] private Transform startPos;
    [SerializeField] private GameObject frog;

    private void Awake()
    {
        onGameStatusChange.Event += status =>
        {
            if (status == GameStatus.Game)
            {
                frog.transform.position = startPos.position;
                frog.SetActive(true);
            }
            
        };
    }
}
