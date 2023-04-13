using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    private static GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        if (obj == null){
            obj = gameObject;
        }
        else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            LoadTitle();
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){

        if (scene.buildIndex == 0){

            GameObject TutorialButton = GameObject.FindGameObjectWithTag("TutorialButton");
            Button Tutorial = TutorialButton.GetComponent<Button>();
		    Tutorial.onClick.AddListener(LoadTutorial);

            GameObject Level1Button = GameObject.FindGameObjectWithTag("Level1Button");
            Button Level1 = Level1Button.GetComponent<Button>();
		    Level1.onClick.AddListener(LoadLevel1);

            GameObject Level2Button = GameObject.FindGameObjectWithTag("Level2Button");
            Button Level2 = Level2Button.GetComponent<Button>();
		    Level2.onClick.AddListener(LoadLevel2);

            GameObject Level3Button = GameObject.FindGameObjectWithTag("Level3Button");
            Button Level3 = Level3Button.GetComponent<Button>();
		    Level3.onClick.AddListener(LoadLevel3);
        }
    }

    public void LoadTitle(){
        SceneManager.LoadScene(0);
        DontDestroyOnLoad(gameObject);
    }

    public void LoadTutorial(){
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel1(){
        SceneManager.LoadScene(2);
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel2(){
        SceneManager.LoadScene(3);
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel3(){
        SceneManager.LoadScene(4);
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
