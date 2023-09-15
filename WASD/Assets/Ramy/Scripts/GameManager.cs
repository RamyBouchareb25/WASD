using UnityEngine;
using UnityEngine.InputSystem;

namespace Ramy.Scripts
{
    public class GameManager : MonoBehaviour, WASD.IPlayerActions
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
            Cursor.lockState = dontShow ?  CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = dontShow;
            Time.timeScale = _instance.isPaused ? 0 : 1;
            _canvas.gameObject.SetActive(_instance.isPaused);
            _instance.isPaused = !_instance.isPaused;
            _spriteBuilding = GetComponent<SpriteBuilding>();
        }

        private void Awake()
        {
            _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            _canvas.gameObject.SetActive(false);
            ShowCursor(false);   
        }

        private WASD player_Controls;
    

        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _spriteBuilding.newLineM();
            }
            print("OnFire");
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            print("OnLook");
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            print("OnMove");
        }

        private void OnEnable()
        {
            if (player_Controls == null)
            {       
                player_Controls = new WASD();
                player_Controls.Player.SetCallbacks(this);
            }
            player_Controls.Enable();
        }

        private void Start()
        {
            player_Controls.Player.Pause.started += OnPause;
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            var pressed = context.performed;
            if (!pressed) return;
            ShowCursor(_instance.isPaused);
        }

        private void Update()
        {
        
            // var pause = player_Controls.Player.Pause.ReadValue<bool>();
            // print(pause);
        }
    }
}
