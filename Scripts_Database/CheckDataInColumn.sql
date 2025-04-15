use Disaster_Relief;

select * from Area;
select * from DisasterLevel;

select * from DisasterType join DisasterLevel on DisasterType.DisasterTypeId = DisasterLevel.DisasterTypeId;

select * from Donor;