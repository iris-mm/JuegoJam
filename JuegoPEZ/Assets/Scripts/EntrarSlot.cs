using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarSlot : MonoBehaviour
{
    private bool enRango;

    void Update()
    {
        
        if (enRango && Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene(4); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enRango = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enRango = false;
        }
    }
}

