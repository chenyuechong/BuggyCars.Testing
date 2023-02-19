Feature: Registration
Registration

Background: 
	Given user open BuggyCars website
	When user click register button on the top

@Registration
Scenario: register with empty field then the register button should be unclickable
	When enter following invalid data 
	| UserName	  | FirstName     | LastName | Password    | ConfirmPassword | 
	|			  | F             |test1     | AaBbCc123!  | AaBbCc123!		 |
	| test1       |               |test1     | AaBbCc123!  | AaBbCc123!		 | 
	| test1       | F             |          | AaBbCc123!  | AaBbCc123!		 |  
	| test1       | F             |test1     |             | AaBbCc123!		 | 
	| test1       | F             |test1     | AaBbCc123!  |				 |
	| test1		  | F             |test1     | AaBbCc123!  | AaBbCc123!!	 |
	Then the register button should be disable

@Registration
Scenario: register with short password then lenght of password error will be present
	When enter following data to register
	| UserName	  | FirstName     | LastName | Password    | ConfirmPassword | 
	| Radom		  | Radom         |test      | 123         | 123		     |
	Then lenght of password error shows in page

@Registration
Scenario: register with no lowercase characters then password police error will be present
	When enter following data to register
	| UserName	  | FirstName     | LastName | Password    | ConfirmPassword | 
	| Radom		  | Radom         |test      | 1231231     | 1231231		 |
	Then password police error shows in page

@Registration
Scenario: valid data should be registered successed
	When enter following data to register
	| UserName	  | FirstName     | LastName | Password    | ConfirmPassword | 
	| Radom		  | Radom         |test      | AaBbCc123!  | AaBbCc123!		 |
	Then register successfully

