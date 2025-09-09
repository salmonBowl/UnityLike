using UnityEngine;

using UnityLike.FrameworkAndDrivers.GameRoop;

namespace UnityLike.FrameworkAndDrivers.PlayButton
{
    [RequireComponent(typeof(GameRoopExecuter))]
    public class PlayButtonsEventManager : MonoBehaviour
    {
        [SerializeField] private PlayButton play;
        [SerializeField] private PlayButton pause;
        [SerializeField] private PlayButton stop;

        private GameRoopExecuter execute;

        void Start()
        {
            execute = GetComponent<GameRoopExecuter>();
        }

        public void OnPushedPlayButton()
        {
            play.Disable();
            pause.Enable();
            stop.Enable();
            execute.OnPlayOrResume();
        }
        public void OnPushedPauseButton()
        {
            play.Enable();
            pause.Disable();
            stop.Enable();
            execute.OnPausePlaying();
        }
        public void OnPushedStopButton()
        {
            play.Enable();
            pause.Disable();
            stop.Disable();
            execute.OnStopPlaying();
        }
    }
}