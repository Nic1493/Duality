using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    protected Canvas thisMenu;
    public GameObject lastSelectedObject { get; private set; }

    protected virtual void Awake()
    {
        thisMenu = GetComponent<Canvas>();
        lastSelectedObject = thisMenu.GetComponentsInChildren<Selectable>()[0].gameObject;
    }

    protected void OpenMenu(Canvas menu)
    {
        menu.enabled = true;
        EventSystem.current.SetSelectedGameObject(menu.GetComponent<Menu>().lastSelectedObject.gameObject);
    }

    protected void CloseMenu(Canvas menu)
    {
        lastSelectedObject = EventSystem.current.currentSelectedGameObject;
        menu.enabled = false;
    }

    public virtual void SwitchMenu(Canvas otherMenu)
    {
        CloseMenu(thisMenu);
        OpenMenu(otherMenu);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}