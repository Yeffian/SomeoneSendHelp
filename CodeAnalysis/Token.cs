using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeoneSendHelp
{
    internal class Token
    {
        public Token(TokenTypes type, object literal, string value)
        {
            Type = type;
            Literal = literal;
            Value = value;
        }

        public TokenTypes Type { get; }
        public object Literal { get; }
        public string Value { get; }

        public override string ToString() => $"Token(Type={Type}, Literal={Literal}, Value={Value})";
    }
}
