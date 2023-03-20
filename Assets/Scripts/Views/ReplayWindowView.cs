using Base;
using Components;
using Presenters;
using TMPro;
using UnityEngine;

namespace Views
{
    public class ReplayWindowView : BaseView<ReplayWindowPresenter>
    {
        [SerializeField] private GameObject replayWindow;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private AudioClip failSound;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            replayWindow.SetActive(true);
            SoundManager.PlayClip(failSound);
        }

        public void Hide()
        {
            replayWindow.SetActive(false);
        }
        
        public void DisplayScore(int score)
        {
            scoreText.text = $"Score: {score}";
        }

        public void Replay()
        {
            Presenter.Replay();
        }

        public void Quit()
        {
            Presenter.Quit();
        }
    }
}