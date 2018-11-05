USE wizball
GO



-- ADMINS
insert into admins values('wizball', 'wizball@gmail.com', 'tpsi1017', default);




-- USER STATES
insert into user_states values('Pending');
insert into user_states values('Blocked');
insert into user_states values('Granted');
go



-- USERS
insert into users values('atec', 'atec@atec.pt', '123123', default, default, getdate(), getdate());



-- USERS HISTORY
insert into user_history values(1, 1, 1, 21, 'User registration', getdate());



-- MARKETS
insert into markets values('Full Time +2,5 Goals', 'ft_over_two_and_half_goals.png');


