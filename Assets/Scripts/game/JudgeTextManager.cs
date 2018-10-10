using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class JudgeTextManager : MonoBehaviour
    {
        public Stopwatch stopwatch;

        private void Start()
        {
            stopwatch = new Stopwatch();
        }

        private void Update()
        {
            if (stopwatch.ElapsedTicks > GameConstants.JUDGE_TEXT_INVISIBLE_TIME)
            {
                gameObject.GetComponent<Text>().text = "";
                stopwatch.Stop();stopwatch.Reset();
            }
        }

    }
}