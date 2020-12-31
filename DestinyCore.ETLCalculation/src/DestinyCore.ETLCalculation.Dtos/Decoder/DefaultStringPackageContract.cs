using SuperSocket.ProtoBase;
using System.Buffers;
using System.Text;

namespace DestinyCore.ETLCalculation.Dtos.Decoder
{
    public class DefaultStringPackageContract : IPackageDecoder<StringPackageInfo>
    {
        public Encoding Encoding { get; private set; }
        public DefaultStringPackageContract(Encoding encoding)
        {
            Encoding = encoding;
        }
        public DefaultStringPackageContract()
            : this(new UTF8Encoding(false))
        {

        }
        public StringPackageInfo Decode(ref ReadOnlySequence<byte> buffer, object context)
        {
            var text = buffer.GetString(Encoding);
            var parts = text.Split(' ', 2);

            var key = parts[0];

            if (parts.Length <= 1)
            {
                return new StringPackageInfo
                {
                    Key = key
                };
            }

            return new StringPackageInfo
            {
                Key = key,
                Body = parts[1],
                Parameters = parts[1].Split(' ')
            };
        }
    }
}
