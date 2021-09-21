using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeoneSendHelp
{
    internal class Lexer
    {
        private string _text;
        private int _position;
        private int _start;
        private List<Token> _tokens { get; } = new List<Token>();
             
        private void Advance() => _position++;
        private void AddToken(Token t) => _tokens.Add(t);

        private char Current
        {
            get
            {
                if (_position >= _text.Length)
                    return '\0';

                return _text[_position];
            }
        }

        public Lexer(string text)
        {
            _text = text;
            _position = 0;
        }

        public Token[] MakeTokens()
        {
            _start = _position;

            while (_position <= _text.Length)
            {
                AddToken(MakeToken());
                Advance();
            }

            AddToken(new Token(TokenTypes.EOFToken, null, string.Empty));
            return _tokens.ToArray();
        }

        public Token MakeNumber()
        {
            while (Char.IsDigit(Current))
                _position++;

            var length = _position - _start;
            var text = _text.Substring(_start, length);

            int.TryParse(text, out int value);


            return new Token(TokenTypes.NumberToken, value, value.ToString());
        }

        private Token MakeToken()
        {
            switch (Current)
            {
                case '+':
                    return new Token(TokenTypes.PlusToken, "+", "+");
                case '-': 
                    return new Token(TokenTypes.MinusToken, "-", "-");
                case '*':
                    return new Token(TokenTypes.AsteriskToken, "*", "*");
                case '/':
                    return new Token(TokenTypes.SlashToken, "/", "/");
                case '\0':
                case '\n':
                case ' ':
                    return new Token(TokenTypes.WhitespaceToken, null, string.Empty);
                default:
                    if (Char.IsDigit(Current))
                        return MakeNumber();

                    return new Token(TokenTypes.BadToken, null, string.Empty);
            }
        } 
    }
}
