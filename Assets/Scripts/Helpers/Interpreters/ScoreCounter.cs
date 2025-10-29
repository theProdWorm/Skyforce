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

        private int Score
        {
            get => _score;
            set
            {
                _score = value;
                UpdateText();
            }
        }
        
        private int Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;
                UpdateText();
            }
        }
        
        private void Start()
        {
            UpdateText();
        }
        
        public void AddScore(int score) => Score += score;

        private void UpdateText()
        {
            _textMeshPro.text = $"{_text}: {Score}";
            
            if (_hasMaximum)
                _textMeshPro.text += $" / {Maximum}";
        }

        public void SetMaximum(int maximum) => Maximum = maximum;
    }
}