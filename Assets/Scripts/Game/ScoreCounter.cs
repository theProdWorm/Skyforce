using TMPro;
using UnityEngine;

namespace Game
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tmp;
        
        private int _score;
        
        public void AddScore(int score)
        {
            _score += score;
            _tmp.text = $"SCORE: {_score}";
        }
    }
}