using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Cogito.IO
{

    public class BlockingStream : Stream
    {

        object _lockForRead;
        object _lockForAll;
        Queue<byte[]> _chunks;
        byte[] _currentChunk;
        int _currentChunkPosition;
        ManualResetEvent _doneWriting;
        ManualResetEvent _dataAvailable;
        WaitHandle[] _events;
        int _doneWritingHandleIndex;
        volatile bool _illegalToWrite;

        public BlockingStream()
        {
            _chunks = new Queue<byte[]>();
            _doneWriting = new ManualResetEvent(false);
            _dataAvailable = new ManualResetEvent(false);
            _events = new WaitHandle[] { _dataAvailable, _doneWriting };
            _doneWritingHandleIndex = 1;
            _lockForRead = new object();
            _lockForAll = new object();
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return !_illegalToWrite; }
        }

        public override void Flush()
        {

        }

        public override long Length
        {
            get { throw new NotSupportedException(); }
        }

        public override long Position
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (offset < 0 || offset >= buffer.Length)
                throw new ArgumentOutOfRangeException("offset");
            if (count < 0 || offset + count > buffer.Length)
                throw new ArgumentOutOfRangeException("count");
            if (_dataAvailable == null)
                throw new ObjectDisposedException(GetType().Name);

            if (count == 0) return 0;

            while (true)
            {
                int handleIndex = WaitHandle.WaitAny(_events);
                lock (_lockForRead)
                {
                    lock (_lockForAll)
                    {
                        if (_currentChunk == null)
                        {
                            if (_chunks.Count == 0)
                            {
                                if (handleIndex == _doneWritingHandleIndex)
                                    return 0;
                                else continue;
                            }
                            _currentChunk = _chunks.Dequeue();
                            _currentChunkPosition = 0;
                        }
                    }

                    int bytesAvailable =
                        _currentChunk.Length - _currentChunkPosition;
                    int bytesToCopy;
                    if (bytesAvailable > count)
                    {
                        bytesToCopy = count;
                        Buffer.BlockCopy(_currentChunk, _currentChunkPosition,
                            buffer, offset, count);
                        _currentChunkPosition += count;
                    }
                    else
                    {
                        bytesToCopy = bytesAvailable;
                        Buffer.BlockCopy(_currentChunk, _currentChunkPosition,
                            buffer, offset, bytesToCopy);
                        _currentChunk = null;
                        _currentChunkPosition = 0;
                        lock (_lockForAll)
                        {
                            if (_chunks.Count == 0) _dataAvailable.Reset();
                        }
                    }
                    return bytesToCopy;
                }
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (offset < 0 || offset >= buffer.Length)
                throw new ArgumentOutOfRangeException("offset");
            if (count < 0 || offset + count > buffer.Length)
                throw new ArgumentOutOfRangeException("count");
            if (_dataAvailable == null)
                throw new ObjectDisposedException(GetType().Name);

            if (count == 0) return;

            byte[] chunk = new byte[count];
            Buffer.BlockCopy(buffer, offset, chunk, 0, count);
            lock (_lockForAll)
            {
                if (_illegalToWrite)
                    throw new InvalidOperationException(
                        "Writing has already been completed.");
                _chunks.Enqueue(chunk);
                _dataAvailable.Set();
            }
        }

        public void SetEndOfStream()
        {
            if (_dataAvailable == null)
                throw new ObjectDisposedException(GetType().Name);
            lock (_lockForAll)
            {
                _illegalToWrite = true;
                _doneWriting.Set();
            }
        }

        public override void Close()
        {
            base.Close();
            if (_dataAvailable != null)
            {
                _dataAvailable.Close();
                _dataAvailable = null;
            }
            if (_doneWriting != null)
            {
                _doneWriting.Close();
                _doneWriting = null;
            }
        }

    }

}
