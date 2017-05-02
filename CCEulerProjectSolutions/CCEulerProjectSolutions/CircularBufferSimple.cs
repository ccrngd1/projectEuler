using System;

namespace CCEulerProjectSolutions
{
    public class CircularBufferSimples : EulerProb
    {
        public override string Solve(string list)
        {
            throw new NotImplementedException();
        }

        public override string SolveSample()
        {
            CircularBufferImp<int> test = new CircularBufferImp<int>(5);

            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);
            test.Add(5);
            test.Add(6);

            return null;
        }
    }

    public class CircularBufferSimpleImp<T>
    {
        public int readPosition = 0;
        public int writePosition = 0;
        public int size = 0;
        public int capacity = 0;

        public T[] _backingArray;

        public CircularBufferSimpleImp(int len)
        {
            size = len;
            _backingArray = new T[len];
        }

        public bool Write(T inputObj)
        {
            if (capacity == size) return false;

            _backingArray[writePosition] = inputObj;
            capacity++;

            writePosition = (writePosition + 1) % size;

            return false;
        }

        public T Read()
        {
            return default(T);
        }        
    }
}
