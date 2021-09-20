using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Canvas))]
public abstract class Menu : MonoBehaviour
{
    protected Canvas thisMenu;
    protected PointerEventData eventData = new PointerEventData(EventSystem.current);

    protected virtual void Awake()
    {
        thisMenu = GetComponent<Canvas>();
    }

    public void Open(GameObject selectedGameObject)
    {
        thisMenu.enabled = true;

        if (thisMenu.TryGetComponent(out Menu m))
            m.Enable(selectedGameObject);   
    }

    public void Close()
    {
        thisMenu.enabled = false;
        Disable();
    }

    public void Enable(GameObject selectedGameObject)
    {
        if (TryGetComponent(out CanvasGroup cg))
        {
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }

        enabled = true;

        if (selectedGameObject != null)
            EventSystem.current.SetSelectedGameObject(selectedGameObject);
    }

    public void Disable()
    {
        if (TryGetComponent(out CanvasGroup cg))
        {
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }

        enabled = false;
    }

    protected void LoadScene(int sceneIndex)
    { 
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}