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
			Compile(code);
			//PrintTree(code,0, false);
		});
	}
});

function Compile(code){
}