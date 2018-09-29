using System.Text;

namespace CommonCode
{
    public sealed class MyStringBuilder
    {
        private StringBuilder sb = new StringBuilder();

        [IsPureExceptLocally]
        public void AppendLine(string line)
        {
            sb.Append(line);
            sb.Append("\r\n");
        }
        [IsPureExceptReadLocally]
        public override string ToString() => sb.ToString();
    }
}
