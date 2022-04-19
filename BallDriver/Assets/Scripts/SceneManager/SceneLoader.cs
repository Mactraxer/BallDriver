using UnityEngine.SceneManagement;

public class SceneLoader
{

    private const string GAME_SCENE_NAME = "GameScene";
    private const string MAIN_MENU_SCENE_NAME = "MainMenuScene";

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE_NAME);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE_NAME);
    }

}
