lexer grammar Pascal;
/*
 * Lexer Rules
 */
// hex digits?
IDENTIFIER          : [A-Za-z_] [A-Za-z0-9_]* ;

COMMENT_1           : '(*' .*? '*)' ;
COMMENT_2           : '{' .*? '}' ;

fragment DIGITSEQ   : [0-9]+  ;
SIGN                : '+' | '-';
SNUMBER             : SIGN DIGITSEQ;
RNUMBER_1           : DIGITSEQ '.' DIGITSEQ;
RNUMBER_2           : DIGITSEQ '.';
SCALE               : ('e' | 'E') SIGN DIGITSEQ;
RNUMSC_1            : RNUMBER_1 SCALE;
RNUMSC_2            : RNUMBER_2 SCALE;
NUMBER              : DIGITSEQ;

CHARSTR             : '\'' .*? '\'' ;
// CHARSTR             : '\'' ('\'\'' | ~ ('\''))* '\'' ;

WHITESPACE          : [\t\r\n] ;

// special like + - ???
SYMBOL              : ([A-Za-z0-9]) ;

// is probably not possible in lexer
// CONTROLSTR          : '#' [0-9]+ ;

