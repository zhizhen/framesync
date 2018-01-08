// author zhizhen
// date 2018/01/08
// email zhzhzhen@gmail.com

using UnityEngine;

namespace Assets.Scripts.Framework
{
    [AutoSingleton(false)]
    public class GameFramework : MonoSingleton<GameFramework>
    {
        protected override void Init()
        {
            Debug.Log("Game Init.");
        }

        public virtual void Start()
        {

            Debug.Log("Game start.");
        }

        private void Update()
        {

            Debug.Log("Game update.");
        }
    }
}