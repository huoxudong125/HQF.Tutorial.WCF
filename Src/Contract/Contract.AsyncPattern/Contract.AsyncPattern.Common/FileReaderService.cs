using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.AsyncPattern.Common
{
    public class FileReaderService : IFileReader
    {
        private const string BaseLocation = @"E:\";
        private FileStream _stream;
        private byte[] _buffer;

        public IAsyncResult BeginRead(string fileName, AsyncCallback userCallback, object stateObject)
        {
            var filepath = Path.Combine(BaseLocation,fileName);
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException(fileName);
            }

            _stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            _buffer = new byte[this._stream.Length];
            return _stream.BeginRead(this._buffer, 0, _buffer.Length, userCallback, stateObject);
        }
        public string EndRead(IAsyncResult ar)
        {
            _stream.EndRead(ar);
            _stream.Close();
            return Encoding.ASCII.GetString(_buffer);
        }


    }
}
