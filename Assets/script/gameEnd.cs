using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameEnd : MonoBehaviour
{
    bool IsGameEnd = false;
    public GameObject btn;
    //public text
    public void endGame()
    {
        if(((gameObject.transform.position-GetComponent<Player_Movement>().playerPosi.position).magnitude > 4) && !IsGameEnd)
        {
            IsGameEnd = true;
            Debug.Log("game end");
            btn.SetActive(true);
            
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        btn.SetActive(false);
    }
}
