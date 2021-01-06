//Created by Jorik Weymans 2020
namespace Jorik.Utilities
{
    //This class helps in keeping track of elapsers (timers). e.g. you need to do something after/for X seconds, this is your class
    public sealed class Elapser
    {
        public bool HasElapsed { get; private set; }

        public float Max { get; private set; } = 0;

        public float Current { get; private set; } = 0;

        public Elapser()
        {
            Max = 0.0f;
            Current = 0.0f;
            HasElapsed = true;
        }
        public Elapser(float elapseTime)
        {
            Max = elapseTime;
            Current = 0.0f;
            HasElapsed = false;
        }

        //Update when you have elpased, only happens once after that it returns false again => call Reset()
        public bool Update(float deltaTime)
        {
            if (HasElapsed) return false;

            Current += deltaTime;
            if (Current >= Max)
            {
                HasElapsed = true;
                return true;
            }
            return false;

        }
        public void Reset()
        {
            HasElapsed = false;
            Current = 0.0f;
        }

        public void Reset(float newElapseTime)
        {
            Max = newElapseTime;
            Reset();

        }
        public void SetMax(float newElapseTime)
        {
            if (newElapseTime >= Current)
                Reset(newElapseTime);
            else
                Max = newElapseTime;
        }
    }

}
