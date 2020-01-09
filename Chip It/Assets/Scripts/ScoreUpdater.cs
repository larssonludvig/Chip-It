using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    private TextMeshProUGUI textMesH;
    private readonly GameManager instance;
    private int score;

    // Start is called before the first frame update
    private void Start() {
        textMesH = GetComponent<TextMeshProUGUI>();
        score = GameManager.instance.GetScore();
    }

    public void Update()
    {
        textMesH.text = "TOTAL HITS: " + score.ToString();
    }
}
