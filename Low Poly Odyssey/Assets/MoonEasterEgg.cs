using UnityEngine;

public class MoonEasterEgg : MonoBehaviour
{
    public GameObject easterEgg;
    public GameObject gameManager;
    bool found = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            easterEgg.SetActive(false);    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainCamera"))
            easterEgg.SetActive(true);

        if (!found)
        {
            gameManager.GetComponent<GameManager>().totalScore += 9001;
            found = true;
        }
    }
}

