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

                homeTeam.WinRating = 1000;
                awayTeam.WinRating = 1000;

                homeTeam.GoalsFor += mMatches[i].HomeScore;
                homeTeam.GoalsAG += mMatches[i].AwayScore;
                awayTeam.GoalsFor += mMatches[i].AwayScore;
                awayTeam.GoalsAG += mMatches[i].HomeScore;
            }
            int counter = 0;
            double Elo = 0;
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
                if (mMatches[i].Event == "FIFA World Cup")
                
                {
                    
                    FIFAcups = FIFAcups + 1;
                    
                        
                        
                        if (homeTeam.WinRating == awayTeam.WinRating)
                        {
                            
                            if (mMatches[i].HomeScore == mMatches[i].AwayScore)
                            {
                                Elo = Elo + 1;
                                Console.Write("1 -");
                            }
                            else if (mMatches[i].HomeScore < mMatches[i].AwayScore)
                            {
                                Elo = Elo + 0.3;
                                Console.Write("0.3 -");
                            }
                            else
                            {
                                Elo = Elo + 0.3;
                                Console.Write("0.3 -");
                            }
                            Console.WriteLine("Draw - " + mMatches[i].Raw);
                        }
                        else if (homeTeam.WinRating > awayTeam.WinRating)
                        {
                            
                            if (mMatches[i].HomeScore == mMatches[i].AwayScore)
                            {
                                Elo = Elo + 0.3;
                                Console.Write("0.3 -");
                            }
                            else if (mMatches[i].HomeScore > mMatches[i].AwayScore)
                            {
                                Elo = Elo + 1;
                                Console.Write("1 -");
                            }
                            else
                            {
                                Elo = Elo + 0;
                                Console.Write("0 -");
                            }
                            Console.WriteLine(mMatches[i].HomeTeam + " wins - " + mMatches[i].Raw);
                        }
                        else
                        {
                            
                            if (mMatches[i].HomeScore == mMatches[i].AwayScore)
                            {
                                Elo = Elo + 0.3;
                                Console.Write("0.3 -");
                            }
                            else if (mMatches[i].HomeScore > mMatches[i].AwayScore)
                            {
                                Elo = Elo + 0;
                                Console.Write("0 -");
                            }
                            else
                            {
                                Elo = Elo + 1;
                                Console.Write("1 -");
                            }
                            Console.WriteLine(mMatches[i].AwayTeam + " wins - " + mMatches[i].Raw);
                            

                        }
                        

                        counter++;
                    
                    
                    
                    

                    
                }
                if (mMatches[i].HomeScore == mMatches[i].AwayScore)
                {


                }
                else if (mMatches[i].HomeScore > mMatches[i].AwayScore)
                {
                    homeTeam.WinRating++;
                    awayTeam.WinRating--;
                }
                else
                {
                    homeTeam.WinRating--;
                    awayTeam.WinRating++;
                }
            }
            Elo = Elo / FIFAcups;
            Console.WriteLine();
            Console.WriteLine(Elo);
        }
    }
}