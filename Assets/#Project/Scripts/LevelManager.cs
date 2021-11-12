using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }
        InitializeScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitializeScene()
    {
        CanvasBehaviour canvas = FindObjectOfType<CanvasBehaviour>(includeInactive:true);
        ItemViewController itemViewController = FindObjectOfType<ItemViewController>();
        Player player = FindObjectOfType<Player>();

        if (player == null)
        {
            Debug.LogError("There is no player in this scene");
            return;
        }
        if (canvas == null)
        {
            Debug.LogError("There is no CanvasBehaviour in this scene");
            return;
        }
        if (itemViewController == null)
        {
            Debug.LogError("There is no ItemViewController in this scene");
            return;
        }

        player.canvas = canvas;
        canvas.player = player;
        player.itemViewController = itemViewController;

        itemViewController.UpdateDisplay();

    }
}
