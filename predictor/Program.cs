using predictor;
using soccer_predictor;
using System.CodeDom.Compiler;

Parser parser = new Parser();
parser.Parse();

List<Match> matches = parser.mMatches;


