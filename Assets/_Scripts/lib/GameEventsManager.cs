using UnityEngine;
using UnityEngine.Events;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }
    public UnityEvent onWin;
    public UnityEvent onDefeat;

    public GameObject pnlWin;
    public GameObject pnlDefeat;


    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(this);

        onWin = new UnityEvent();
        onDefeat = new UnityEvent();

        onWin.AddListener(ActPanelWin);
        onDefeat.AddListener(ActPanelDef);

    }

    void ActPanelWin()
    {
        pnlWin.SetActive(true);
    }
    void ActPanelDef()
    {
        pnlDefeat.SetActive(true);
    }

    public void BtnReloadActiveScene()
    {
        SceneManagerMulti.instance.ReLoadLastScene();
    }
    public void BtnLoadMenuScene()
    {
        SceneManagerMulti.instance.LoadScene(0);
    }
    public void BtnLoadNextScene()
    {
        SceneManagerMulti.instance.LoadScene("");
    }
}
