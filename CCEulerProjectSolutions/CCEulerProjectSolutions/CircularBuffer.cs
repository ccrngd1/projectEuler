using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    public class CircularBuffer : EulerProb
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

    public class CircularBufferImp<T> : IEnumerable<T>, IEnumerator<T>, ICollection<T>
    {
        int readPosition = 0;
        int writePosition = 0;
        int size = 0;
        int capacity = 0;

        T[] _backingArray;

        public CircularBufferImp(int len)
        {
            size = len;
            _backingArray = new T[len];
        }

        public T this[int key]
        {
            get
            {
                return GetValue(key);
            }
            set
            {
                SetValue(key, value);
            }
        }

        public void SetValue(int key, T value)
        {
            throw new NotImplementedException();
        }

        public T GetValue(int key)
        {
            if (readPosition > writePosition)
            {
                if ((key >= readPosition || key < writePosition) && key < size - 1)
                {
#if DEBUG
                    if (_backingArray[key].Equals(default(T)))
                        Console.WriteLine("Is this wrong?");
#endif

                    return _backingArray[key];
                }
                throw new ArgumentOutOfRangeException();
            }
            else if (writePosition > readPosition)
            {
                if((key<writePosition && key >= readPosition) && key < size - 1)
                {

#if DEBUG
                    if (_backingArray[key].Equals(default(T)))
                        Console.WriteLine("is this wrong?");
#endif

                    return _backingArray[key];
                }
                throw new ArgumentOutOfRangeException();
            }
            else
                throw new Exception();
        }

        public T Current => _backingArray[readPosition];
        
        public int Count => size;

        public bool IsReadOnly => false;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (writePosition == readPosition && capacity==size)
                return false;

            readPosition = (readPosition + 1) % size;

            return true;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CircularBufferImp() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        public void Add(T item)
        {
            if (!MoveWriteNext())
                return;

            _backingArray[writePosition] = item;
        }

        private bool MoveWriteNext()
        {
            if (writePosition != -1)
            {
                if (writePosition + 1 == readPosition || (writePosition + 1 == size && readPosition == 0))
                    return false;
            }

            writePosition++;

            if (writePosition == size) writePosition = 0;

            return true;
        }

        public void Clear()
        {
            _backingArray = new T[size];

            readPosition = 0;
            writePosition = 0;
        }

        public bool Contains(T item)
        {
            int tempReadPos = readPosition;

            while (tempReadPos != writePosition)
            {
                if (_backingArray[tempReadPos].Equals(item))
                    return true;

                tempReadPos++;

                if (tempReadPos >= size)
                    tempReadPos = 0;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (size > array.Length) throw new IndexOutOfRangeException();

            for(int i=0; i<size; i++)
            {
                array[arrayIndex + i] = _backingArray[i];
            }
        }

        public bool Remove(T item)
        {
            if(_backingArray[writePosition].Equals(item))
            {
                //do we need to clear out memory?
                //_backingArray[writePosition] = default(T);

                writePosition--;

                if (writePosition < 0) writePosition = size - 1;

                return true;
            }

            return false;
        }

        public void Reset()
        {
            Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            while (readPosition != writePosition)
            {
                if (!MoveNext()) break;

                yield return _backingArray[readPosition];

            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (readPosition != writePosition)
            {
                if (!MoveNext()) break;

                yield return _backingArray[readPosition];
            }
        }

        #endregion

    }
}
