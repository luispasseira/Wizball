use wizball
go

delete from matches
delete from teams
delete from competitions
delete from seasons
delete from areas

select * from tips
select * from areas
select * from seasons where id= 160
select * from competitions where name like '%Premier League%'
select * from competitions where id = 2003
select * from teams where id = 516 or id = 511
select COUNT(home_team_id) as fds, home_team_id, utc_date, last_updated from matches 
where utc_date < GETDATE()
group by home_team_id, utc_date, last_updated
order by home_team_id , utc_date

select * from matches where home_team_id = 355  order by utc_date asc 
select * from users
select * from user_history

select * from teams where id = 1903

select * from competitions
inner join areas on competitions.area_id = areas.id
order by competitions.id asc

select * from matches where competition_id = 2017
order by utc_date asc

select * from areas

select * from user_history
where user_id = 1 order by created_at desc


update matches set utc_date = '2018-08-1 20:59:00', ft_home_team=4, ft_away_team=2 where id = 234701