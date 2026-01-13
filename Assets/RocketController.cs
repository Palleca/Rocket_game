using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    public float vitesseDescente;
    public InputActionReference toucheMonte;
    public bool jumpPressed;
    public GameObject canvas;

    void Start()
    {
        canvas.SetActive(false);
    }

    void Update()
    {
        if (jumpPressed == false)
        {
            transform.position -= new Vector3(0, vitesseDescente * Time.deltaTime, 0);
        }
        else
        {
            transform.position += new Vector3(0, vitesseDescente * Time.deltaTime, 0);
        }
    }

    private void OnEnable()
    {
        toucheMonte.action.Enable();
        toucheMonte.action.performed += OnJumpPressed;
        toucheMonte.action.canceled += OnJumpReleased;
    }

    private void OnDisable()
    {
        toucheMonte.action.performed -= OnJumpPressed;
        toucheMonte.action.canceled -= OnJumpReleased;
        toucheMonte.action.Disable();
    }

    private void OnJumpPressed(InputAction.CallbackContext context)
    {
        jumpPressed = true;
    }

    private void OnJumpReleased(InputAction.CallbackContext context)
    {
        jumpPressed = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Sol")
        {
            canvas.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
