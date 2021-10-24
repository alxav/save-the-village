using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject winPanel;

    public void OpenStartPanel()
    {
        SetVisiblePanel(startPanel, true);
    }
    
    public void CloseStartPanel()
    {
        SetVisiblePanel(startPanel, false);
    }
    
    public void OpenWinPanel()
    {
        SetVisiblePanel(winPanel, true);
    }

    private void SetVisiblePanel(GameObject panel, bool flag)
    {
        if (panel)
            panel.SetActive(flag);
    }
    
}
