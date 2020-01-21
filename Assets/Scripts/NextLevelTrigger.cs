using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    public GameObject go;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameWatcher.CurrentEnemiesCount <= 0 && GameWatcher.CurrentEnemiesKilled > 0)
            {
                Instantiate(go,
                        transform.position + new Vector3(0, 0, 25),
                        Quaternion.identity);
                    gameObject.SetActive(false);
            }
        }
    }
}