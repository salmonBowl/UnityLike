using UnityEngine;

namespace UnityLike.Presentation
{
    public class TitleSceneMain : Main
    {
        [SerializeField] ApplicationFactory application;

        // C#ƒNƒ‰ƒX‚Ì‰Šú‰»‚ğ‚µ‚Ü‚·
        protected override void Awake()
        {
            currentScene.Is(new GameScene(application));
        }
    }
}
