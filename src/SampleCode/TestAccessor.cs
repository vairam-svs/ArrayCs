using System;

namespace SampleCode
{
    public class TestAccessor
    {
        private int _Prop;
        public int Prop
        {
            get {
                return _Prop;
            }
            private set
            {
                _Prop = value;
            }
        }

        public TestAccessor(int prop)
        {
            Prop = prop;
        }

    }
}