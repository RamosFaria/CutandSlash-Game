using UnityEngine;
using UnityEngine.UI;

public class StrikeManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] strikeSpriteSheet;

    private Image strikeImage;

    public static StrikeManager Instance { get; private set; }
    private void Start()
    {
        Actions.StrikeHandler += SetStrike;
        strikeImage = GetComponent<Image>();
        Instance = this;
    }

    private void OnDisable()
    {
        Actions.StrikeHandler -= SetStrike;
    }

    public void SetStrike()
    {
        
        if(Application.isPlaying)
        {
            strikeImage.sprite = strikeSpriteSheet[UIGame.Instance.Strike];
        }
        
    }
}
