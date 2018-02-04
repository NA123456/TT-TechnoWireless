/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO Course AS Target 
USING (VALUES 
        (1, 'English'), 
        (2, 'Arabic'), 
        (3, 'Physics'),
		(4, 'Math')
) 
AS Source (Id, CourseName) 
ON Target.Id = Source.Id 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (CourseName) 
VALUES (CourseName);

