using System.IO;
using System.Net.Sockets;

namespace ShpGck.Tcp
{
    public class TcpGeckoStream : GeckoStream
    {
        private NetworkStream BaseStream;

        public TcpGeckoStream(NetworkStream baseStream)
        {
            BaseStream = baseStream;
        }

        public override int Read(byte[] buffer, int offset, int count)
            => BaseStream.Read(buffer, offset, count);

        public override void Write(byte[] buffer, int offset, int count)
            => BaseStream.Write(buffer, offset, count);

        public override void Flush() => BaseStream.Flush();

        public override long Seek(long offset, SeekOrigin origin)
            => BaseStream.Seek(offset, origin);

        public override void SetLength(long value) => BaseStream.SetLength(value);

        public override bool CanRead => BaseStream.CanRead;

        public override bool CanWrite => BaseStream.CanWrite;

        public override bool CanSeek => BaseStream.CanSeek;

        public override long Position
        {
            get => BaseStream.Position;
            set => BaseStream.Position = value;
        }

        public override long Length => BaseStream.Length;

    }
}
