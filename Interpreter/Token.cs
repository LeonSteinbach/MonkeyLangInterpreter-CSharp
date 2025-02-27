﻿namespace Interpreter
{
	public enum TokenType
	{
		ILLEGAL,
		EOF,

		IDENT,
		INT,
		STRING,

		ASSIGN,
		PLUS,
		MINUS,
		BANG,
		ASTERIX,
		SLASH,

		LT,
		GT,

		COMMA,
		COLON,
		SEMICOLON,

		LPAREN,
		RPAREN,
		LBRACE,
		RBRACE,
		LBRACKET,
		RBRACKET,

		TRUE,
		FALSE,

		IF,
		ELSE,

		RETURN,

		EQ,
		NEQ,

		FUNCTION,
		LET,
	}

	public class Token
	{
		public string Literal { get; set; }
		public TokenType Type { get; set; }

		public static Dictionary<string, TokenType> keywords = new()
		{
			{"fn", TokenType.FUNCTION},
			{"let", TokenType.LET},
			{"true", TokenType.TRUE},
			{"false", TokenType.FALSE},
			{"if", TokenType.IF},
			{"else", TokenType.ELSE},
			{"return", TokenType.RETURN},
		};

		public Token(TokenType tokenType, string literal)
		{
			Type = tokenType;
			this.Literal = literal;
		}

		public static TokenType LookupIdent(string ident)
		{
			return keywords.ContainsKey(ident) ? keywords[ident] : TokenType.IDENT;
		}

		public static bool operator ==(Token token1, Token token2)
		{
			return (token1 is null && token2 is null) || (!(token1 is null) && !(token2 is null) && token1.Type == token2.Type && token1.Literal == token2.Literal);
		}

		public static bool operator !=(Token token1, Token token2)
		{
			return !(token1 == token2);
		}

		public override string ToString()
		{
			return "{ Type: " + Type + ", Literal: " + Literal + " }";
		}
	}
}
