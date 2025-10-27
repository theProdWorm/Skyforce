using System;
using TMPro;
using UnityEngine;

namespace Helpers.Interpreters
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        [SerializeField] private string _text;
        [SerializeField] private bool _hasMaximum;
        [SerializeField] private int _maximum;
        
        private int _score;
        
        private void Start()
        {
            UpdateText();
        }
        
        public void AddScore(int score)
        {
            _score += score;
            UpdateText();
        }

        private void UpdateText()
        {
            _textMeshPro.text = $"{_text}: {_score}";
            
            if (_hasMaximum)
                _textMeshPro.text += $" / {_maximum}";
        }
        
        public void SetMaximum(int maximum) => _maximum = maximum;
        public void SetMaximum(Func<int> callback) => _maximum = callback();
    }
}