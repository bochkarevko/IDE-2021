//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/cyril/RiderProjects/HomeWork1/PasLexer/Pascal.g4 by ANTLR 4.9.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.1")]
[System.CLSCompliant(false)]
public partial class Pascal : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		IDENTIFIER=1, COMMENT=2, CHARACTERSTRING=3, UNSIGNEDNUMBER=4, SIGNEDNUMBER=5, 
		WHITESPACE=6;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"IDENTIFIER", "COMMENT", "COMMENT_1", "COMMENT_2", "COMMENT_3", "CHARACTERSTRING", 
		"UNSIGNEDNUMBER", "SIGNEDNUMBER", "UNSIGNEDINTEGER", "UNSIGNEDREAL", "BINARYSEQUENCE", 
		"OCTALSEQUENCE", "DIGITSEQ", "HEXSEQUENCE", "SIGN", "SCALE", "WHITESPACE"
	};


	public Pascal(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public Pascal(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
	};
	private static readonly string[] _SymbolicNames = {
		null, "IDENTIFIER", "COMMENT", "CHARACTERSTRING", "UNSIGNEDNUMBER", "SIGNEDNUMBER", 
		"WHITESPACE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Pascal.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static Pascal() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\b', '\xB5', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x3', '\x2', '\x3', 
		'\x2', '\a', '\x2', '(', '\n', '\x2', '\f', '\x2', '\xE', '\x2', '+', 
		'\v', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x5', '\x3', '\x30', 
		'\n', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\a', 
		'\x4', '\x36', '\n', '\x4', '\f', '\x4', '\xE', '\x4', '\x39', '\v', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\a', '\x4', '=', '\n', '\x4', '\f', '\x4', 
		'\xE', '\x4', '@', '\v', '\x4', '\x3', '\x4', '\a', '\x4', '\x43', '\n', 
		'\x4', '\f', '\x4', '\xE', '\x4', '\x46', '\v', '\x4', '\x5', '\x4', 'H', 
		'\n', '\x4', '\x3', '\x4', '\a', '\x4', 'K', '\n', '\x4', '\f', '\x4', 
		'\xE', '\x4', 'N', '\v', '\x4', '\x3', '\x4', '\a', '\x4', 'Q', '\n', 
		'\x4', '\f', '\x4', '\xE', '\x4', 'T', '\v', '\x4', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\a', '\x5', '[', '\n', 
		'\x5', '\f', '\x5', '\xE', '\x5', '^', '\v', '\x5', '\x3', '\x5', '\x5', 
		'\x5', '\x61', '\n', '\x5', '\x3', '\x5', '\a', '\x5', '\x64', '\n', '\x5', 
		'\f', '\x5', '\xE', '\x5', 'g', '\v', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\a', '\x6', 'o', 
		'\n', '\x6', '\f', '\x6', '\xE', '\x6', 'r', '\v', '\x6', '\x3', '\a', 
		'\x3', '\a', '\a', '\a', 'v', '\n', '\a', '\f', '\a', '\xE', '\a', 'y', 
		'\v', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x5', 
		'\b', '\x7F', '\n', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', 
		'\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x5', '\n', '\x88', '\n', 
		'\n', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x5', '\v', 
		'\x8E', '\n', '\v', '\x5', '\v', '\x90', '\n', '\v', '\x3', '\v', '\x5', 
		'\v', '\x93', '\n', '\v', '\x3', '\f', '\x3', '\f', '\x6', '\f', '\x97', 
		'\n', '\f', '\r', '\f', '\xE', '\f', '\x98', '\x3', '\r', '\x3', '\r', 
		'\x6', '\r', '\x9D', '\n', '\r', '\r', '\r', '\xE', '\r', '\x9E', '\x3', 
		'\xE', '\x6', '\xE', '\xA2', '\n', '\xE', '\r', '\xE', '\xE', '\xE', '\xA3', 
		'\x3', '\xF', '\x3', '\xF', '\x6', '\xF', '\xA8', '\n', '\xF', '\r', '\xF', 
		'\xE', '\xF', '\xA9', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', '\x3', 
		'\x11', '\x5', '\x11', '\xB0', '\n', '\x11', '\x3', '\x11', '\x3', '\x11', 
		'\x3', '\x12', '\x3', '\x12', '\a', '\x37', 'L', 'R', '\\', '\x65', '\x2', 
		'\x13', '\x3', '\x3', '\x5', '\x4', '\a', '\x2', '\t', '\x2', '\v', '\x2', 
		'\r', '\x5', '\xF', '\x6', '\x11', '\a', '\x13', '\x2', '\x15', '\x2', 
		'\x17', '\x2', '\x19', '\x2', '\x1B', '\x2', '\x1D', '\x2', '\x1F', '\x2', 
		'!', '\x2', '#', '\b', '\x3', '\x2', '\xF', '\x5', '\x2', '\x43', '\\', 
		'\x61', '\x61', '\x63', '|', '\x6', '\x2', '\x32', ';', '\x43', '\\', 
		'\x61', '\x61', '\x63', '|', '\x3', '\x2', ',', ',', '\x3', '\x2', '}', 
		'}', '\x3', '\x2', '\f', '\f', '\x4', '\x2', '\f', '\f', ')', ')', '\x3', 
		'\x2', '\x32', '\x33', '\x3', '\x2', '\x32', '\x39', '\x3', '\x2', '\x32', 
		';', '\x5', '\x2', '\x32', ';', '\x43', 'H', '\x63', 'h', '\x4', '\x2', 
		'-', '-', '/', '/', '\x4', '\x2', 'G', 'G', 'g', 'g', '\x5', '\x2', '\v', 
		'\f', '\xF', '\xF', '\"', '\"', '\x2', '\xC4', '\x2', '\x3', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\r', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', '\x2', 
		'\x3', '%', '\x3', '\x2', '\x2', '\x2', '\x5', '/', '\x3', '\x2', '\x2', 
		'\x2', '\a', '\x31', '\x3', '\x2', '\x2', '\x2', '\t', 'X', '\x3', '\x2', 
		'\x2', '\x2', '\v', 'j', '\x3', '\x2', '\x2', '\x2', '\r', 's', '\x3', 
		'\x2', '\x2', '\x2', '\xF', '~', '\x3', '\x2', '\x2', '\x2', '\x11', '\x80', 
		'\x3', '\x2', '\x2', '\x2', '\x13', '\x87', '\x3', '\x2', '\x2', '\x2', 
		'\x15', '\x89', '\x3', '\x2', '\x2', '\x2', '\x17', '\x94', '\x3', '\x2', 
		'\x2', '\x2', '\x19', '\x9A', '\x3', '\x2', '\x2', '\x2', '\x1B', '\xA1', 
		'\x3', '\x2', '\x2', '\x2', '\x1D', '\xA5', '\x3', '\x2', '\x2', '\x2', 
		'\x1F', '\xAB', '\x3', '\x2', '\x2', '\x2', '!', '\xAD', '\x3', '\x2', 
		'\x2', '\x2', '#', '\xB3', '\x3', '\x2', '\x2', '\x2', '%', ')', '\t', 
		'\x2', '\x2', '\x2', '&', '(', '\t', '\x3', '\x2', '\x2', '\'', '&', '\x3', 
		'\x2', '\x2', '\x2', '(', '+', '\x3', '\x2', '\x2', '\x2', ')', '\'', 
		'\x3', '\x2', '\x2', '\x2', ')', '*', '\x3', '\x2', '\x2', '\x2', '*', 
		'\x4', '\x3', '\x2', '\x2', '\x2', '+', ')', '\x3', '\x2', '\x2', '\x2', 
		',', '\x30', '\x5', '\a', '\x4', '\x2', '-', '\x30', '\x5', '\t', '\x5', 
		'\x2', '.', '\x30', '\x5', '\v', '\x6', '\x2', '/', ',', '\x3', '\x2', 
		'\x2', '\x2', '/', '-', '\x3', '\x2', '\x2', '\x2', '/', '.', '\x3', '\x2', 
		'\x2', '\x2', '\x30', '\x6', '\x3', '\x2', '\x2', '\x2', '\x31', '\x32', 
		'\a', '*', '\x2', '\x2', '\x32', '\x33', '\a', ',', '\x2', '\x2', '\x33', 
		'L', '\x3', '\x2', '\x2', '\x2', '\x34', '\x36', '\a', '*', '\x2', '\x2', 
		'\x35', '\x34', '\x3', '\x2', '\x2', '\x2', '\x36', '\x39', '\x3', '\x2', 
		'\x2', '\x2', '\x37', '\x38', '\x3', '\x2', '\x2', '\x2', '\x37', '\x35', 
		'\x3', '\x2', '\x2', '\x2', '\x38', ':', '\x3', '\x2', '\x2', '\x2', '\x39', 
		'\x37', '\x3', '\x2', '\x2', '\x2', ':', 'K', '\x5', '\x5', '\x3', '\x2', 
		';', '=', '\a', '*', '\x2', '\x2', '<', ';', '\x3', '\x2', '\x2', '\x2', 
		'=', '@', '\x3', '\x2', '\x2', '\x2', '>', '<', '\x3', '\x2', '\x2', '\x2', 
		'>', '?', '\x3', '\x2', '\x2', '\x2', '?', 'H', '\x3', '\x2', '\x2', '\x2', 
		'@', '>', '\x3', '\x2', '\x2', '\x2', '\x41', '\x43', '\a', ',', '\x2', 
		'\x2', '\x42', '\x41', '\x3', '\x2', '\x2', '\x2', '\x43', '\x46', '\x3', 
		'\x2', '\x2', '\x2', '\x44', '\x42', '\x3', '\x2', '\x2', '\x2', '\x44', 
		'\x45', '\x3', '\x2', '\x2', '\x2', '\x45', 'H', '\x3', '\x2', '\x2', 
		'\x2', '\x46', '\x44', '\x3', '\x2', '\x2', '\x2', 'G', '>', '\x3', '\x2', 
		'\x2', '\x2', 'G', '\x44', '\x3', '\x2', '\x2', '\x2', 'H', 'I', '\x3', 
		'\x2', '\x2', '\x2', 'I', 'K', '\n', '\x4', '\x2', '\x2', 'J', '\x37', 
		'\x3', '\x2', '\x2', '\x2', 'J', 'G', '\x3', '\x2', '\x2', '\x2', 'K', 
		'N', '\x3', '\x2', '\x2', '\x2', 'L', 'M', '\x3', '\x2', '\x2', '\x2', 
		'L', 'J', '\x3', '\x2', '\x2', '\x2', 'M', 'R', '\x3', '\x2', '\x2', '\x2', 
		'N', 'L', '\x3', '\x2', '\x2', '\x2', 'O', 'Q', '\a', ',', '\x2', '\x2', 
		'P', 'O', '\x3', '\x2', '\x2', '\x2', 'Q', 'T', '\x3', '\x2', '\x2', '\x2', 
		'R', 'S', '\x3', '\x2', '\x2', '\x2', 'R', 'P', '\x3', '\x2', '\x2', '\x2', 
		'S', 'U', '\x3', '\x2', '\x2', '\x2', 'T', 'R', '\x3', '\x2', '\x2', '\x2', 
		'U', 'V', '\a', ',', '\x2', '\x2', 'V', 'W', '\a', '+', '\x2', '\x2', 
		'W', '\b', '\x3', '\x2', '\x2', '\x2', 'X', '\\', '\a', '}', '\x2', '\x2', 
		'Y', '[', '\n', '\x5', '\x2', '\x2', 'Z', 'Y', '\x3', '\x2', '\x2', '\x2', 
		'[', '^', '\x3', '\x2', '\x2', '\x2', '\\', ']', '\x3', '\x2', '\x2', 
		'\x2', '\\', 'Z', '\x3', '\x2', '\x2', '\x2', ']', '`', '\x3', '\x2', 
		'\x2', '\x2', '^', '\\', '\x3', '\x2', '\x2', '\x2', '_', '\x61', '\x5', 
		'\x5', '\x3', '\x2', '`', '_', '\x3', '\x2', '\x2', '\x2', '`', '\x61', 
		'\x3', '\x2', '\x2', '\x2', '\x61', '\x65', '\x3', '\x2', '\x2', '\x2', 
		'\x62', '\x64', '\n', '\x5', '\x2', '\x2', '\x63', '\x62', '\x3', '\x2', 
		'\x2', '\x2', '\x64', 'g', '\x3', '\x2', '\x2', '\x2', '\x65', '\x66', 
		'\x3', '\x2', '\x2', '\x2', '\x65', '\x63', '\x3', '\x2', '\x2', '\x2', 
		'\x66', 'h', '\x3', '\x2', '\x2', '\x2', 'g', '\x65', '\x3', '\x2', '\x2', 
		'\x2', 'h', 'i', '\a', '\x7F', '\x2', '\x2', 'i', '\n', '\x3', '\x2', 
		'\x2', '\x2', 'j', 'k', '\a', '\x31', '\x2', '\x2', 'k', 'l', '\a', '\x31', 
		'\x2', '\x2', 'l', 'p', '\x3', '\x2', '\x2', '\x2', 'm', 'o', '\n', '\x6', 
		'\x2', '\x2', 'n', 'm', '\x3', '\x2', '\x2', '\x2', 'o', 'r', '\x3', '\x2', 
		'\x2', '\x2', 'p', 'n', '\x3', '\x2', '\x2', '\x2', 'p', 'q', '\x3', '\x2', 
		'\x2', '\x2', 'q', '\f', '\x3', '\x2', '\x2', '\x2', 'r', 'p', '\x3', 
		'\x2', '\x2', '\x2', 's', 'w', '\a', ')', '\x2', '\x2', 't', 'v', '\n', 
		'\a', '\x2', '\x2', 'u', 't', '\x3', '\x2', '\x2', '\x2', 'v', 'y', '\x3', 
		'\x2', '\x2', '\x2', 'w', 'u', '\x3', '\x2', '\x2', '\x2', 'w', 'x', '\x3', 
		'\x2', '\x2', '\x2', 'x', 'z', '\x3', '\x2', '\x2', '\x2', 'y', 'w', '\x3', 
		'\x2', '\x2', '\x2', 'z', '{', '\a', ')', '\x2', '\x2', '{', '\xE', '\x3', 
		'\x2', '\x2', '\x2', '|', '\x7F', '\x5', '\x13', '\n', '\x2', '}', '\x7F', 
		'\x5', '\x15', '\v', '\x2', '~', '|', '\x3', '\x2', '\x2', '\x2', '~', 
		'}', '\x3', '\x2', '\x2', '\x2', '\x7F', '\x10', '\x3', '\x2', '\x2', 
		'\x2', '\x80', '\x81', '\x5', '\x1F', '\x10', '\x2', '\x81', '\x82', '\x5', 
		'\xF', '\b', '\x2', '\x82', '\x12', '\x3', '\x2', '\x2', '\x2', '\x83', 
		'\x88', '\x5', '\x1B', '\xE', '\x2', '\x84', '\x88', '\x5', '\x17', '\f', 
		'\x2', '\x85', '\x88', '\x5', '\x1D', '\xF', '\x2', '\x86', '\x88', '\x5', 
		'\x19', '\r', '\x2', '\x87', '\x83', '\x3', '\x2', '\x2', '\x2', '\x87', 
		'\x84', '\x3', '\x2', '\x2', '\x2', '\x87', '\x85', '\x3', '\x2', '\x2', 
		'\x2', '\x87', '\x86', '\x3', '\x2', '\x2', '\x2', '\x88', '\x14', '\x3', 
		'\x2', '\x2', '\x2', '\x89', '\x92', '\x5', '\x1B', '\xE', '\x2', '\x8A', 
		'\x8B', '\a', '\x30', '\x2', '\x2', '\x8B', '\x8D', '\x5', '\x1B', '\xE', 
		'\x2', '\x8C', '\x8E', '\x5', '!', '\x11', '\x2', '\x8D', '\x8C', '\x3', 
		'\x2', '\x2', '\x2', '\x8D', '\x8E', '\x3', '\x2', '\x2', '\x2', '\x8E', 
		'\x90', '\x3', '\x2', '\x2', '\x2', '\x8F', '\x8A', '\x3', '\x2', '\x2', 
		'\x2', '\x8F', '\x90', '\x3', '\x2', '\x2', '\x2', '\x90', '\x93', '\x3', 
		'\x2', '\x2', '\x2', '\x91', '\x93', '\x5', '!', '\x11', '\x2', '\x92', 
		'\x8F', '\x3', '\x2', '\x2', '\x2', '\x92', '\x91', '\x3', '\x2', '\x2', 
		'\x2', '\x93', '\x16', '\x3', '\x2', '\x2', '\x2', '\x94', '\x96', '\a', 
		'\'', '\x2', '\x2', '\x95', '\x97', '\t', '\b', '\x2', '\x2', '\x96', 
		'\x95', '\x3', '\x2', '\x2', '\x2', '\x97', '\x98', '\x3', '\x2', '\x2', 
		'\x2', '\x98', '\x96', '\x3', '\x2', '\x2', '\x2', '\x98', '\x99', '\x3', 
		'\x2', '\x2', '\x2', '\x99', '\x18', '\x3', '\x2', '\x2', '\x2', '\x9A', 
		'\x9C', '\a', '(', '\x2', '\x2', '\x9B', '\x9D', '\t', '\t', '\x2', '\x2', 
		'\x9C', '\x9B', '\x3', '\x2', '\x2', '\x2', '\x9D', '\x9E', '\x3', '\x2', 
		'\x2', '\x2', '\x9E', '\x9C', '\x3', '\x2', '\x2', '\x2', '\x9E', '\x9F', 
		'\x3', '\x2', '\x2', '\x2', '\x9F', '\x1A', '\x3', '\x2', '\x2', '\x2', 
		'\xA0', '\xA2', '\t', '\n', '\x2', '\x2', '\xA1', '\xA0', '\x3', '\x2', 
		'\x2', '\x2', '\xA2', '\xA3', '\x3', '\x2', '\x2', '\x2', '\xA3', '\xA1', 
		'\x3', '\x2', '\x2', '\x2', '\xA3', '\xA4', '\x3', '\x2', '\x2', '\x2', 
		'\xA4', '\x1C', '\x3', '\x2', '\x2', '\x2', '\xA5', '\xA7', '\a', '&', 
		'\x2', '\x2', '\xA6', '\xA8', '\t', '\v', '\x2', '\x2', '\xA7', '\xA6', 
		'\x3', '\x2', '\x2', '\x2', '\xA8', '\xA9', '\x3', '\x2', '\x2', '\x2', 
		'\xA9', '\xA7', '\x3', '\x2', '\x2', '\x2', '\xA9', '\xAA', '\x3', '\x2', 
		'\x2', '\x2', '\xAA', '\x1E', '\x3', '\x2', '\x2', '\x2', '\xAB', '\xAC', 
		'\t', '\f', '\x2', '\x2', '\xAC', ' ', '\x3', '\x2', '\x2', '\x2', '\xAD', 
		'\xAF', '\t', '\r', '\x2', '\x2', '\xAE', '\xB0', '\x5', '\x1F', '\x10', 
		'\x2', '\xAF', '\xAE', '\x3', '\x2', '\x2', '\x2', '\xAF', '\xB0', '\x3', 
		'\x2', '\x2', '\x2', '\xB0', '\xB1', '\x3', '\x2', '\x2', '\x2', '\xB1', 
		'\xB2', '\x5', '\x1B', '\xE', '\x2', '\xB2', '\"', '\x3', '\x2', '\x2', 
		'\x2', '\xB3', '\xB4', '\t', '\xE', '\x2', '\x2', '\xB4', '$', '\x3', 
		'\x2', '\x2', '\x2', '\x1B', '\x2', ')', '/', '\x37', '>', '\x44', 'G', 
		'J', 'L', 'R', '\\', '`', '\x65', 'p', 'w', '~', '\x87', '\x8D', '\x8F', 
		'\x92', '\x98', '\x9E', '\xA3', '\xA9', '\xAF', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
