using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class goBack : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Skip()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
