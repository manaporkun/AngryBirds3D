using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    public GameObject player;
    
    public void ResetScene()
    {
        SceneManager.LoadScene(0);
        //Instantiate(player, new Vector3(-4.33306837f, 3.58266187f, -5.81172752f), new Quaternion(0f, 0f, 0f, 0f));
    }
}
