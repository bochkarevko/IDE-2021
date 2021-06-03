lexer grammar Pascal;
/*
 * Lexer Rules
 */
//fragment LETTER     : [A-Za-z] ;
//fragment DIGIT      : [0-9] ;
//fragment HEXDIGIT   : [0-9A-Fa-f] ;
//SYMBOL              : LETTER | DIGIT | HEXDIGIT ;
 
IDENTIFIER          : [A-Za-z_] [A-Za-z0-9_]* ;

COMMENT             : COMMENT_1 | COMMENT_2 | COMMENT_3;
fragment COMMENT_1           : '(*' ('('*? COMMENT | ('('* | '*'*) ~[*])*? '*'*? '*)' ;
fragment COMMENT_2           : '{' ((~('{')*?) COMMENT? ~('{')*?) '}' ;
fragment COMMENT_3           : '//' ~('\n')* ;

CHARACTERSTRING     : '\'' (~ ('\'' | '\n'))* '\'' ;

UNSIGNEDNUMBER  : UNSIGNEDINTEGER | UNSIGNEDREAL ;
SIGNEDNUMBER    : SIGN UNSIGNEDNUMBER ;

fragment UNSIGNEDINTEGER    : DIGITSEQ | BINARYSEQUENCE | HEXSEQUENCE | OCTALSEQUENCE ;
fragment UNSIGNEDREAL       : DIGITSEQ (('.' DIGITSEQ (SCALE)?)? | SCALE) ;

fragment BINARYSEQUENCE : '%' [0-1]+ ;
fragment OCTALSEQUENCE  : '&' [0-7]+ ;
fragment DIGITSEQ       : [0-9]+ ;
fragment HEXSEQUENCE    : '$' [0-9A-Fa-f]+ ;
fragment SIGN           : '+' | '-' ;
fragment SCALE          : ('e' | 'E') SIGN? DIGITSEQ ;

WHITESPACE          : [\t\r\n] ;
