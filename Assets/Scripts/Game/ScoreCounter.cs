using TMPro;
using UnityEngine;

namespace Game
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        [SerializeField] private string _text;
        
        private int _score;
        
        public void AddScore(int score)
        {
            _score += score;
            _textMeshPro.text = $"{_text}: {_score}";
        }
    }
}