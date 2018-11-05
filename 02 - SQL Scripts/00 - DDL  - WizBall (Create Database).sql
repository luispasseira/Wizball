CREATE DATABASE wizball
GO

USE wizball
GO


BEGIN TRY
	
	BEGIN TRANSACTION

						CREATE TABLE admins
						(
							id						int					identity(1, 10)				not null,
							username				varchar(50)			unique						not null,											
							email					varchar(50)			unique						not null,
							password				varchar(50)										not null,
							pic						varchar(50)			default('admin.png')		not null,

							constraint pk_admins primary key(id)
						)

						CREATE TABLE user_states
						(
							id						int					identity(1, 10)				not null,
							description				varchar(50)			unique						not null,											

							constraint pk_user_states primary key(id)
						)

						CREATE TABLE users
						(
							id						int					identity(1, 10)				not null,
							username				varchar(50)			unique						not null,											
							email					varchar(50)			unique						not null,
							password				varchar(50)										not null,
							newsletter				bit					default(0)					not null,
							pic						varchar(50)			default('user.png')			not null,
							created_at				datetime			default(getdate())			not null,
							updated_at				datetime										not null,

							constraint pk_users primary key(id),
						)

						CREATE TABLE user_history
						(
							id						int					identity(1, 1)				not null,
							admin_id				int												not null,
							user_id					int					    						not null,											
							before_state_id			int												not null,
							after_state_id			int												not null,
							[description]			varchar(150)									not null,
							created_at				datetime			default(getdate())			not null,

							constraint pk_user_history primary key(id),
							constraint fk_admin foreign key(admin_id) references admins(id),
							constraint fk_user foreign key(user_id) references users(id),
							constraint fk_before_state foreign key(before_state_id) references user_states(id),
							constraint fk_after_state foreign key(after_state_id) references user_states(id)
						)

						CREATE TABLE areas
						(
							id						int												not null,
							name					varchar(50)			unique						not null,											
							country_code			varchar(50)			unique						not null,
							parent_area_id			int												null	,

							constraint pk_areas primary key(id)
						)


						CREATE TABLE seasons
						(
							id						int												not null,
							start_date				date											null	,											
							end_date				date											null	,

							constraint pk_seasons primary key(id)
						)


						CREATE TABLE competitions
						(
							id						int												not null,
							area_id					int												not null,											
							name					varchar(50)										not null,
							code					varchar(50)										null	,
							[plan]					varchar(50)										not null,
							flag					varchar(50)										null	,
							last_updated			datetime										not null,

							constraint pk_competitions primary key(id),
							constraint fk_competitions_area_id foreign key(area_id) references areas(id)
						)


						CREATE TABLE teams
						(
							id						int												not null,
							area_id					int												null	,											
							name					varchar(50)			unique						not null,
							short_name				varchar(50)										null	,
							tla						varchar(50)										null    ,
							address					varchar(150)									null	,
							phone					varchar(50)										null	,
							website					varchar(100)									null	,
							email					varchar(100)									null	,
							founded					int												null	,
							club_colors				varchar(50)										null	,
							venue					varchar(100)									null	,
							flag					varchar(50)										null	,
							last_updated			datetime										null	,

							constraint pk_teams primary key(id),
							constraint fk_teams_area_id foreign key(area_id) references areas(id)
						)


						CREATE TABLE matches
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
							last_updated			datetime										not null,

							constraint pk_matches primary key(id),
							constraint fk_matches_season_id foreign key(season_id) references seasons(id),
							constraint fk_matches_competition_id foreign key(competition_id) references competitions(id),
							constraint fk_matches_home_team_id foreign key(home_team_id) references teams(id),
							constraint fk_matches_away_team_id foreign key(away_team_id) references teams(id)
						)


						CREATE TABLE markets
						(
							id						int					identity(1, 10)				not null,
							description				varchar(50)			unique						not null,
							pic						varchar(50)			unique						not null,											

							constraint pk_markets primary key(id)
						)


						CREATE TABLE tips
						(
							id						int					identity(1, 1)				not null,
							match_id				int												not null,
							market_id				int												not null,
							bet_no_bet				bit												not null,
							forecast				bit												not null,
							result					bit												null	,											

							constraint pk_tips primary key(id),
							constraint fk_tips_match_id foreign key(match_id) references matches(id),
							constraint fk_tips_market_id foreign key(market_id) references markets(id)
						)


						CREATE TABLE newsletters
						(
							id						int					identity(1, 10)				not null,
							title					varchar(100)									not null,	
							body					varchar(max)									not null,
							admin_id				int												not null,
							created_at				datetime										not null,
							sent_at					datetime										null	,										

							constraint pk_newsletters primary key(id),
							constraint fk_newsletters_admin_id foreign key(admin_id) references admins(id)
						)
						

	COMMIT TRANSACTION

	PRINT 'WizBall database successfully created.'

END TRY

BEGIN CATCH
			
	ROLLBACK TRANSACTION
	PRINT (@@ERROR)

END CATCH

