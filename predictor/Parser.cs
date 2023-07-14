using predictor;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soccer_predictor
{
    internal class Parser
    {
        public List<Match> mMatches = new List<Match>();
        public List<Team> mTeams = new List<Team>();

        public void Parse()
        {
            string contents = File.ReadAllText("..\\..\\..\\..\\results.csv");
            string[] lines = contents.Split('\n');

            //Parse all the matches
            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].Length < 5)
                {
                    continue;
                }
                mMatches.Add(new Match(lines[i]));
            }
            double rd = 0;
            for (int i = 0; i < mMatches.Count; i++)
            {
                Team? homeTeam = mTeams.Find(x => x.Name == mMatches[i].HomeTeam);
                if (homeTeam == null)
                {
                    homeTeam = new Team(mMatches[i].HomeTeam);
                    mTeams.Add(homeTeam);
                }

                Team? awayTeam = mTeams.Find(x => x.Name == mMatches[i].AwayTeam);
                if (awayTeam == null)
                {
                    awayTeam = new Team(mMatches[i].AwayTeam);
                    mTeams.Add(awayTeam);
                }

                homeTeam.EloRating = 1000;
                awayTeam.EloRating = 1000;

                homeTeam.GoalsFor += mMatches[i].HomeScore;
                homeTeam.GoalsAG += mMatches[i].AwayScore;
                awayTeam.GoalsFor += mMatches[i].AwayScore;
                awayTeam.GoalsAG += mMatches[i].HomeScore;
            }
            double af = 0;
            int lose = 0;
            int win = 0;
            int mov = 0;
            int t = 0;
            double ar = 0;
            double er = 0;
            double counter = 0;
            double prediction = 0;
            double matchPrediction= 0;
            int FIFAcups = 0;
            for (int i = 0; i < mMatches.Count; i++)
            {

                Team? homeTeam = mTeams.Find(x => x.Name == mMatches[i].HomeTeam);
                if (homeTeam == null)
                {
                    homeTeam = new Team(mMatches[i].HomeTeam);
                    mTeams.Add(homeTeam);
                }

                Team? awayTeam = mTeams.Find(x => x.Name == mMatches[i].AwayTeam);
                if (awayTeam == null)
                {
                    awayTeam = new Team(mMatches[i].AwayTeam);
                    mTeams.Add(awayTeam);
                }
                if (mMatches[i].nuetral == "FALSE")
                {

                    homeTeam.EloRating = homeTeam.EloRating + 100;

                }
                if (mMatches[i].HomeScore == mMatches[i].AwayScore)
                {
                    win = mMatches[i].HomeScore;
                    lose = mMatches[i].AwayScore;
                }
                else if (mMatches[i].HomeScore > mMatches[i].AwayScore)
                {
                    win = mMatches[i].HomeScore;
                    lose = mMatches[i].AwayScore;
                }
                else
                {
                    win = mMatches[i].AwayScore;
                    lose = mMatches[i].HomeScore;
                }
                rd = homeTeam.EloRating - awayTeam.EloRating;
                er = 1 / (Math.Pow(10, -1 * rd / 400) + 1);
                mov = win - lose;
                if (mov <= 1)
                {
                    af = 1;
                   
                }
                if (mov == 2)
                {
                    af = 1.5;

                }
                if (mov == 3)
                {
                    af = 1.75;

                }
                if (mov >= 4)
                {
                    af = 1.9;

                }
                //if (mMatches[i].Event == "FIFA World Cup")
                {


                    if (rd <= 50 && rd >= -50)
                    {
                            
                        if (mMatches[i].HomeScore == mMatches[i].AwayScore)
                        {
                            matchPrediction = 1;
                            Console.Write("1 -");
                            ar = 0.5;
                        }
                        else if (mMatches[i].HomeScore < mMatches[i].AwayScore)
                        {
                            matchPrediction = 0.3;
                            Console.Write("0.3 -");
                            ar = 0;
                        }
                        else
                        {
                            matchPrediction = 0.3;
                            Console.Write("0.3 -");
                            ar = 1;
                        }
                        Console.WriteLine("Draw - " + mMatches[i].Raw);
                    }
                    else if (rd > 50)
                    {
                            
                        if (mMatches[i].HomeScore == mMatches[i].AwayScore)
                        {
                            matchPrediction = 0.3;
                            Console.Write("0.3 -");
                            ar = 0.5;
                        }
                        else if (mMatches[i].HomeScore > mMatches[i].AwayScore)
                        {
                            matchPrediction = 1;
                            Console.Write("1 -");
                            ar = 1;
                        }
                        else
                        {
                            matchPrediction = 0;
                            Console.Write("0 -");
                            ar = 0;
                        }
                        Console.WriteLine(mMatches[i].HomeTeam + " wins - " + mMatches[i].Raw);
                    }
                    else
                    {
                            
                        if (mMatches[i].HomeScore == mMatches[i].AwayScore)
                        {
                            matchPrediction = 0.3;
                            Console.Write("0.3 -");
                            ar = 0.5;
                        }
                        else if (mMatches[i].HomeScore > mMatches[i].AwayScore)
                        {
                            matchPrediction = 0;
                            Console.Write("0 -");
                            ar = 1;
                        }
                        else
                        {
                            matchPrediction = 1;
                            Console.Write("1 -");
                            ar = 0;
                        }
                        Console.WriteLine(mMatches[i].AwayTeam + " wins - " + mMatches[i].Raw);
                    }
                    homeTeam.EloRating = homeTeam.EloRating + 40 * (ar - er) * af;
                    awayTeam.EloRating = awayTeam.EloRating - 40 * (ar - er) * af;
                    counter++;

                    if (mMatches[i].Event == "FIFA World Cup")
                    {
                        FIFAcups = FIFAcups + 1;
                        prediction += matchPrediction;
                    }
                }
                if (mMatches[i].nuetral == "FALSE")
                {
                    homeTeam.EloRating = homeTeam.EloRating - 100;

                }

                
            }
            prediction = prediction / FIFAcups;
            Console.WriteLine();
            Console.WriteLine(prediction);
        }
    }
}