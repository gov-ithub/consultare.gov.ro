delete from proposals
delete from institutions


select  distinct([Inițiator]) as institution into #temp from proposalstemp 

insert into Institutions (name, id) 
select institution, newid() from #temp

drop table #temp
insert into proposals (
id,
InstitutionId,
Title,
StartDate,
LimitDate,
EndDate,
Link,
Email
)
select newid() as id, 
(select id from institutions where name=[Inițiator]) as institutionId, 
[Denumire act normativ] as title,
case when isdate(cast(luna as varchar(255)) + '/' + cast(zi as varchar(255)) + '/' + cast(an as varchar(255))) = 1 then 
cast(cast(luna as varchar(255)) + '/' + cast(zi as varchar(255)) + '/' + cast(an as varchar(255)) as date) 
when isdate(cast(luna1 as varchar(255)) + '/' + cast(zi1 as varchar(255)) + '/' + cast(an1 as varchar(255))) = 1 then
Dateadd(d, -[Nr# zile (calend)], cast(cast(luna1 as varchar(255)) + '/' + cast(zi1 as varchar(255)) + '/' + cast(an1 as varchar(255)) as date)) else null
end as startDate,
case when isdate(cast(luna1 as varchar(255)) + '/' + cast(zi1 as varchar(255)) + '/' + cast(an1 as varchar(255))) = 1 then 
cast(cast(luna1 as varchar(255)) + '/' + cast(zi1 as varchar(255)) + '/' + cast(an1 as varchar(255)) as date) 
when isdate(cast(luna as varchar(255)) + '/' + cast(zi as varchar(255)) + '/' + cast(an as varchar(255))) = 1 then
Dateadd(d, [Nr# zile (calend)], cast(cast(luna as varchar(255)) + '/' + cast(zi as varchar(255)) + '/' + cast(an as varchar(255)) as date)) else null
end as limitDate,
cast(cast(luna2 as varchar(255)) + '/' + cast(zi2 as varchar(255)) + '/' + cast(an2 as varchar(255)) as date) as endDate, 
[Linkul act normativ] as Link, 
[Adresa pentru mai multe detalii și transmiterea sugestiilor] as Email
from Proposalstemp