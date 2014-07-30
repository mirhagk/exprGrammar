var exec = require('child_process').exec;
var parserFile = './exprGrammar';
var testCode = './exprGrammar.txt';
var fs = require('fs');
var util = require('util');

var child = exec('pegjs '+parserFile+'.peg '+parserFile+'.peg.js',function(err,stdout,stderr){
	if (err)
		console.log(err);
	else{
		console.log('compiled');
		var parser = require(parserFile+'.peg.js');

		
		fs.readFile(testCode,'utf8',function(err,data){
			//console.log('result %j', parser.parse(data));
			var code = parser.parse(data);
			console.log(util.inspect(code,{depth:null}));
			console.log(Compile(code));
			//PrintTree(code,0, false);
		});
	}
});

function Compile(code){
	return CompileToJava(code);
}


  function replaceLastElse(condition, elseBranch){
      if (condition[3]==null){
          condition[3] = elseBranch;
          return condition;
      }
      condition[3] = replaceLastElse(condition[3], elseBranch);
      return condition;
  }
  function StringFlatten(arr){
     if (arr.length==0) return "";
     return arr.reduce(function(prev,cur){
        return prev+cur;
     });
  }
  binOperators = { 	"AND": {op:"&&", prec:20}, 
					"OR": { op:"||", prec:21}, 
					"+": { op:"+", prec:2}, 
					"*": { op:"*", prec:1}, 
					"=": { op:"==", prec:12}, 
					"<": { op:"<", prec:10}, 
					">": { op:">", prec:10}, 
					}
	function HighestPrecendence(expression){
		var precedence = 0;
		if (binOperators[expression[0]]!=undefined){
			precedence = binOperators[expression[0]].prec;
		}
             if (Array.isArray(expression))
		expression.forEach(function(x){
			if (Array.isArray(x)){
				var prec = HighestPrecendence(x);
				if (prec>precedence)
					precedence=prec;
			}
		});
		return precedence;
	}
	function MaybeParens(expression, operator){
	    var precedence = 0;
		if (binOperators[operator] != undefined)
			precedence = binOperators[operator].prec;
		var highestPrecedence = HighestPrecendence(expression);
		if (highestPrecedence>precedence)
			return "(" + CompileToJava(expression) + ")";
		return CompileToJava(expression);
	}
  function CompileToJava(tree){
    if (typeof tree == "number")
        return tree;
    if (typeof tree == "string"){
        if (tree[0]=='@')
            return "scope."+tree.slice(1);
        return tree;
    }
    if (tree==null||tree.length==0)
        return "";
    if (binOperators[tree[0]]!=undefined)
        return MaybeParens(CompileToJava(tree[1]))+binOperators[tree[0]].op+MaybeParens(CompileToJava(tree[2]));
    if (tree[0]=="IFELSE")
        return MaybeParens(tree[1]) + "?"+MaybeParens(tree[2])+":"+MaybeParens(tree[3]);
    return tree[0] +"(" + MaybeParens(tree[1]) + ")";
  }
  function ArrayFlatten(arr){
     result =  arr.reduce(function(prev,cur){
        return prev.concat(cur);
     });
     return result.filter(function(x){return x!=null;});
  }