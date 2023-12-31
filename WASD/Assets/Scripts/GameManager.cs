using UnityEngine;
using UnityEngine.InputSystem;

namespace Ramy.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        private GameManager()
        {

        }

        public static GameManager Instance()
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }

            return _instance;

        }

        public bool isPaused { get; private set; } = false;
        private Canvas _canvas;
        private SpriteBuilding _spriteBuilding;
        public void ShowCursor(bool dontShow)
        {
            print("show");
            Cursor.lockState = dontShow ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = dontShow;
            Time.timeScale = _instance.isPaused ? 0 : 1;
            _canvas.gameObject.SetActive(_instance.isPaused);
            _instance.isPaused = !_instance.isPaused;
            _spriteBuilding = GetComponent<SpriteBuilding>();
        }

        private void Awake()
        {
            _instance = Instance();
            _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            _canvas.gameObject.SetActive(false);
            ShowCursor(false);
        }



        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _spriteBuilding.newLineM();
            }
            print("OnFire");
        }



        public void OnBuildMode(InputAction.CallbackContext context)
        {
            var pressed = context.performed;
            print("build ! : " + pressed);
            if (!pressed) return;
            ShowCursor(_instance.isPaused);
        }

    }
}
