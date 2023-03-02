using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public void OnButtonPlay() {
        SceneManager.LoadScene(1);
        print("asd");
    }
}
