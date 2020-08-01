public class ClearMenu : Menu
{
    protected override void Awake()
    {
        base.Awake();
        FindObjectOfType<Goal>().levelClearedAction += OnLevelClear;
    }
    
    void OnLevelClear()
    {
        OpenMenu(thisMenu);
    }
}
