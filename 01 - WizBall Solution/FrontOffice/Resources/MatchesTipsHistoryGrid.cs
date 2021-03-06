﻿using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using BusinessLogic.Entities;
using BusinessLogic.BLL;
using System.Linq;

namespace FrontOffice.Resources
{
    public class MatchesTipsHistoryGrid
    {
        BLL bll;
        public MatchesTipsHistoryGrid()
        {
            bll = new Globals().CreateBll();  
        }


        private HtmlGenericControl Filters()
        {
            // Container
            HtmlGenericControl filters      = new HtmlGenericControl("div");
            filters.Attributes["id"]        = "filters";
            filters.Attributes["class"]     = "filters";
           

            // All comps filter.
            HtmlGenericControl allComps     = new HtmlGenericControl("div");
            allComps.Attributes["id"]       = "filters-opts";
            allComps.Attributes["class"]    = "filters-opts";
            allComps.InnerHtml = "<span id='show-all-outter'>All</span><pipe>|</pipe>" +
                                 "<span id='show-none-outter'>None</span>";
            filters.Controls.Add(allComps);

            List<Competition> competitions  = bll.TierOneCompetitions();
            foreach(Competition comp in competitions)
            {
                Competition fullComp = bll.GetCompetitionById(comp.Id.ToString());

                HtmlGenericControl competition      = new HtmlGenericControl("div");
                competition.Attributes["class"]     = "competition";
                competition.Attributes["id"]        = fullComp.Id.ToString();


                string compName         = fullComp.Name.Replace(" ", "");
                competition.InnerHtml   = "<img id='" + compName + "' CompId='" + fullComp.Id + "' class='competition-flag' src='" + Globals.COMP_FLAGS + fullComp.Flag + "' alt='" + fullComp.Name + "' title='" + fullComp.Name + "' />";


                filters.Controls.Add(competition);
            }

            return filters;
        }

        private HtmlGenericControl Grid()
        {
            // Grid to return.
            HtmlGenericControl grid = new HtmlGenericControl("div");
            grid.Attributes["id"] = "grid";
            grid.Attributes["class"] = "grid";

            // Header.
            HtmlGenericControl header = new HtmlGenericControl("div");
            header.Attributes["id"] = "grid-header";
            header.Attributes["class"] = "grid-header";
            grid.Controls.Add(header);

            // Scrollable.
            HtmlGenericControl scroll = new HtmlGenericControl("div");
            scroll.Attributes["id"] = "grid-body-scrollable";
            scroll.Attributes["class"] = "grid-body-scrollable";
            grid.Controls.Add(scroll);


            // Body.
            HtmlGenericControl body = new HtmlGenericControl("div");
            body.Attributes["class"] = "grid-body";
            body.Attributes["id"] = "grid-body";
            scroll.Controls.Add(body);





            // Header cells.
            HtmlGenericControl cellCompetition  = new HtmlGenericControl("div");
            cellCompetition.Attributes["id"]    = "header-cell-competitions";
            cellCompetition.Attributes["class"] = "grid-cell";
            cellCompetition.Attributes["title"] = "Competition";
            cellCompetition.InnerHtml           = "Comp <i class='fas fa-long-arrow-alt-down' style='color:transparent;'></i>";
            header.Controls.Add(cellCompetition);

            HtmlGenericControl cellMatchDay     = new HtmlGenericControl("div");
            cellMatchDay.Attributes["class"]    = "grid-cell";
            cellMatchDay.Attributes["title"]    = "Match Day";
            cellMatchDay.InnerHtml = "MD";
            header.Controls.Add(cellMatchDay);

            HtmlGenericControl cellDate         = new HtmlGenericControl("div");
            cellDate.Attributes["id"]           = "header-cell-date";
            cellDate.Attributes["class"]        = "grid-cell";
            cellDate.Attributes["title"]        = "Match Date";
            cellDate.InnerHtml                  = "Date <i class='fas fa-long-arrow-alt-down' style='color:greenyellow;'></i>";
            header.Controls.Add(cellDate);

            HtmlGenericControl cellHomeTeam     = new HtmlGenericControl("div");
            cellHomeTeam.Attributes["class"]    = "grid-cell";
            cellHomeTeam.Attributes["title"]    = "Home Team";
            cellHomeTeam.InnerHtml              = "Home Team";
            header.Controls.Add(cellHomeTeam);

            HtmlGenericControl cellScore        = new HtmlGenericControl("div");
            cellScore.Attributes["class"]       = "grid-cell";
            cellScore.Attributes["title"]       = "Full-time score";
            cellScore.InnerHtml                 = "Score";
            header.Controls.Add(cellScore);

            HtmlGenericControl cellAwayTeam     = new HtmlGenericControl("div");
            cellAwayTeam.Attributes["class"]    = "grid-cell";
            cellAwayTeam.Attributes["title"]    = "Away Team";
            cellAwayTeam.InnerText              = "Away Team";
            header.Controls.Add(cellAwayTeam);

            HtmlGenericControl cellFtOverTwoAndHalGoals     = new HtmlGenericControl("div");
            cellFtOverTwoAndHalGoals.Attributes["id"]       = "header-cell-ftotahg";
            cellFtOverTwoAndHalGoals.Attributes["class"]    = "grid-cell";
            cellFtOverTwoAndHalGoals.Attributes["title"]    = "Full-time over two and half goals";
            cellFtOverTwoAndHalGoals.InnerHtml              = "FT +2.5 <i class='fas fa-long-arrow-alt-down' style='color:transparent;'></i>";
            header.Controls.Add(cellFtOverTwoAndHalGoals);

            HtmlGenericControl cellOutcome                  = new HtmlGenericControl("div");
            cellOutcome.Attributes["id"]                    = "header-cell-outcome";
            cellOutcome.Attributes["class"]                 = "grid-cell";
            cellOutcome.Attributes["title"]                 = "Outcome";
            cellOutcome.InnerHtml                           = "Out <i class='fas fa-long-arrow-alt-down' style='color:transparent;'></i>";
            header.Controls.Add(cellOutcome);

            DateTime startDate  = DateTime.UtcNow.AddDays(-10);
            DateTime endDate    = DateTime.UtcNow.AddHours(-3);
            List<Match> matches = bll.GetHistoryMatchesByTierOneCompetitions().OrderByDescending(x => bll.NormalizeApiDateTime(x.UtcDate)).ToList();
            foreach (Match match in matches)
            {
                // Rows
                HtmlGenericControl row      = new HtmlGenericControl("div");
                row.Attributes["class"]     = "grid-row";
                row.Attributes["CompId"]    = match.Competition.Id.ToString();
                row.Attributes["dateTime"]  = (bll.NormalizeApiDateTime(match.UtcDate).Value.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMinutes).ToString();



                // Row cells.
                HtmlGenericControl rowCellCompetition   = new HtmlGenericControl("div");
                rowCellCompetition.Attributes["class"]  = "grid-cell";
                rowCellCompetition.InnerHtml            = "<img src='" + Globals.COMP_FLAGS + match.Competition.Flag + "' alt='" + match.Competition.Name + "' title='" + match.Competition.Name + "' width ='20px;'>";
                row.Controls.Add(rowCellCompetition);

                HtmlGenericControl rowCellMatchDay      = new HtmlGenericControl("div");
                rowCellMatchDay.Attributes["class"]     = "grid-cell";
                rowCellMatchDay.InnerHtml               = match.Matchday.ToString();
                row.Controls.Add(rowCellMatchDay);

                HtmlGenericControl rowCellDate          = new HtmlGenericControl("div");
                rowCellDate.Attributes["id"]            = "utc-date";
                rowCellDate.Attributes["class"]         = "grid-cell";
                rowCellDate.Attributes["utc-date"]      = bll.NormalizeApiDateTime(match.UtcDate).Value.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds.ToString();
                rowCellDate.InnerHtml                   = bll.NormalizeApiDateTime(match.UtcDate).Value.ToString("dd MMM HH:mm");
                row.Controls.Add(rowCellDate);

                HtmlGenericControl rowCellHomeTeam      = new HtmlGenericControl("div");
                rowCellHomeTeam.Attributes["class"]     = "grid-cell";
                rowCellHomeTeam.InnerHtml               = match.HomeTeam.ShortName + "<img class='teamFlag pl-2' src='" + Globals.TEAM_FLAGS + match.Competition.Area.Name + "/" + match.HomeTeam.Flag + "' alt='" + match.HomeTeam.ShortName + "' title='" + match.HomeTeam.ShortName + "' width='20px;'>";
                row.Controls.Add(rowCellHomeTeam);

                HtmlGenericControl rowCellScore         = new HtmlGenericControl("div");
                rowCellScore.Attributes["class"]        = "grid-cell";
                rowCellScore.InnerHtml                  = match.Score.FullTime.HomeTeam.ToString() + "-" + match.Score.FullTime.AwayTeam.ToString();
                row.Controls.Add(rowCellScore);

                HtmlGenericControl rowCellAwayTeam      = new HtmlGenericControl("div");
                rowCellAwayTeam.Attributes["class"]     = "grid-cell";
                rowCellAwayTeam.InnerHtml               = "<img class='teamFlag pr-2' src='" + Globals.TEAM_FLAGS + match.Competition.Area.Name + "/" + match.AwayTeam.Flag + "' alt='" + match.AwayTeam.ShortName + "' title='" + match.AwayTeam.ShortName + "' width='20px;'> " + match.AwayTeam.ShortName;
                row.Controls.Add(rowCellAwayTeam);


                // Tips and outcome columns
                Tip tip = bll.GetTipByMatchId(match.Id.ToString());
                row.Attributes["ftotahg"] = tip is null ? "4" : tip.BetNoBet == false ? "3" : tip.Forecast == true ? "1" : "2";

                HtmlGenericControl rowCellTip           = new HtmlGenericControl("div");
                rowCellTip.Attributes["class"]          = "grid-cell";            
                if (tip != null)
                {
                    if (tip.BetNoBet)
                    {
                        if (tip.Forecast)
                        {
                            rowCellTip.Attributes["style"] = "color: green";
                            rowCellTip.InnerHtml = "<span title='Bet in favor full-time over two and half goals'>+2.5</span>";
                        }
                        else
                        {
                            rowCellTip.Attributes["style"] = "color: red";
                            rowCellTip.InnerHtml = "<span title='Bet against full-time over two and half goals'>-2.5</span>";
                        }
                    }
                    else
                    {
                        rowCellTip.InnerHtml = "<span title='Unpredictable'>No bet</span>";
                    }
                }
                else
                {
                    rowCellTip.InnerHtml = "<span title='Not available'>N/A</span>";
                }
                row.Controls.Add(rowCellTip);


                HtmlGenericControl rowCellOutcome   = new HtmlGenericControl("div");
                rowCellOutcome.Attributes["class"]  = "grid-cell";
                if (tip != null && tip.Result != null)
                {
                    if (tip.BetNoBet)
                    {
                        if (tip.Forecast)
                        {
                            if((bool)tip.Result)
                            {
                                row.Attributes["outcome"] = "0";
                                rowCellOutcome.Attributes["style"] = "color: green";
                                rowCellOutcome.InnerHtml = "<img class='outcomeImg' src='" + Globals.WIZBALL + "yes.png' alt='Img success' title='Successful tip' />";
                            }
                            else
                            {
                                row.Attributes["outcome"] = "1";
                                rowCellOutcome.Attributes["style"] = "color: red";
                                rowCellOutcome.InnerHtml = "<img class='outcomeImg' src='" + Globals.WIZBALL + "no.png' alt='Img fail' title='Failed tip' />";
                            }
                        }
                        else
                        {
                            if ((bool)tip.Result)
                            {
                                row.Attributes["outcome"] = "1";
                                rowCellOutcome.Attributes["style"] = "color: red";
                                rowCellOutcome.InnerHtml = "<img class='outcomeImg' src='" + Globals.WIZBALL + "no.png' alt='Img fail' title='Failed tip' />";                              
                            }
                            else
                            {
                                row.Attributes["outcome"] = "0";
                                rowCellOutcome.Attributes["style"] = "color: green";
                                rowCellOutcome.InnerHtml = "<img class='outcomeImg' src='" + Globals.WIZBALL + "yes.png' alt='Img success' title='Successful tip' />";

                            }
                        }
                    }
                    else
                    {
                        int? result = match.Score.FullTime.HomeTeam + match.Score.FullTime.AwayTeam;
                        if(result < 2.5)
                        {
                            row.Attributes["outcome"] = "3";
                            rowCellOutcome.InnerHtml = "<span title='Outcome -2.5 goals' style='color:red;'>-2.5</span>";
                        }
                        else
                        {
                            row.Attributes["outcome"] = "2";
                            rowCellOutcome.InnerHtml = "<span title='Outcome +2.5 goals' style='color:green;'>+2.5</span>";
                        }
                        
                    }
                }
                else
                {
                    row.Attributes["outcome"] = "4";
                    rowCellOutcome.InnerHtml = "<span title='Not available'>N/A</span>";
                }
                row.Controls.Add(rowCellOutcome);


                body.Controls.Add(row);
            }

            return grid;
        }



        public HtmlGenericControl FiltersAndGrid()
        {
            HtmlGenericControl filtersAndGrid   = new HtmlGenericControl("div");
            filtersAndGrid.Attributes["id"]     = "filtersAndGrid";
            filtersAndGrid.Attributes["class"]  = "filtersAndGrid";

            filtersAndGrid.Controls.Add(Filters());

            filtersAndGrid.Controls.Add(Grid());

            return filtersAndGrid;
        }
    }
}