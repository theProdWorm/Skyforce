using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helpers.Game
{
    public class SceneHandler : MonoBehaviour
    {
        public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
        public void LoadScene(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
        public void QuitGame() => Application.Quit();

        public void LoadSceneMulti(string sceneName) => SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        public void LoadSceneMulti(int sceneIndex) => SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
    }
}
