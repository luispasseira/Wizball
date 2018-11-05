USE wizball
GO

CREATE PROC spGetNextMatches @competition INT
AS BEGIN

	DECLARE		@matches TABLE															-- Returning table.
	(
		id						int												not null,
		season_id				int												not null,	
		competition_id			int												not null,										
		utc_date				datetime										not null,
		matchday				int												    null,
		stage					varchar(50)										null	,
		[group]					varchar(50)										null	,
		attendance				int												null	,
		duration				varchar(50)										null	,
		winner					varchar(50)										null	,
		home_team_id			int												not null,
		away_team_id			int												not null,
		ht_home_team			int												null	,
		ht_away_team			int												null	,
		ft_home_team			int												null	,
		ft_away_team			int												null	,
		et_home_team			int												null	,
		et_away_team			int												null	,
		pt_home_team			int												null	,
		pt_away_team			int												null	,
		last_updated			datetime										not null
	)				
		

	DECLARE		@team	 INT															-- Variables to iterate through @teams cursor.
	DECLARE		@date	 DATE
	DECLARE		@teams   CURSOR 														
	
	SET			@teams = CURSOR FOR														-- Cursor with teams_id and date, belonging to a specific competition.
	SELECT		DISTINCT(home_team_id), MIN(utc_date) AS utc_date						-- Date is necessary so we can iterate throughout the teams by the correct order.
	FROM		matches 
	WHERE		competition_id = @competition AND utc_date >= CONVERT(DATE, GETDATE())
	GROUP BY	home_team_id 
	ORDER BY	utc_date


	OPEN @teams																					-- Opens cursor.

		FETCH NEXT FROM @teams INTO @team, @date												-- Gets first team (team_id, date).

		WHILE (@@FETCH_STATUS = 0) 	
		BEGIN 

			INSERT INTO @matches	SELECT	TOP 1 *												
									FROM	matches 
									WHERE	competition_id = @competition 
									AND		utc_date >= CONVERT(date ,GETUTCDATE())
									AND	   (matches.home_team_id = @team OR matches.away_team_id = @team) 
									AND		NOT EXISTS (
														SELECT	* 
														FROM	@matches AS m 
														WHERE	m.home_team_id = matches.home_team_id
															 OR m.home_team_id = matches.away_team_id
															 OR m.away_team_id = matches.home_team_id
															 OR m.away_team_id = matches.away_team_id
														)
									ORDER BY utc_date ASC

			FETCH NEXT FROM @teams INTO @team, @date

		END 

	CLOSE	   @teams
	DEALLOCATE @teams

	SELECT * FROM @matches ORDER BY utc_date ASC

end