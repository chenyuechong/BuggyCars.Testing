Feature: VoteModel
As the model will just be voted for once, generat a new user first

Background: 
	Given user open BuggyCars website
	When user click register button on the top
	And enter following data to register
	| UserName	  | FirstName     | LastName | Password    | ConfirmPassword | 
	| Radom		  | Radom         |test      | AaBbCc123!  | AaBbCc123!		 |
	Then register successfully
	Then use creditial to login

@vote
Scenario: vote a model 	
	When click populor model
    And add a comment "No.1 model"
	And click vote button
	Then votes should plus one