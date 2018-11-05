use wizball
go

select utc_date, tone.short_name, ft_home_team, ft_away_team, ttwo.short_name, bet_no_bet, forecast, result, ft_home_team + ft_away_team as total
from matches
inner join tips on matches.id = tips.match_id
inner join teams tone on matches.home_team_id = tone.id
inner join teams ttwo on matches.away_team_id = ttwo.id
where result is null
order by utc_date desc