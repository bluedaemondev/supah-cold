using UnityEngine;
using UnityEngine.Events;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }
    public UnityEvent onWin;
    public UnityEvent onDefeat;

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(this);

        onWin = new UnityEvent();
        onDefeat = new UnityEvent();
    }

}
