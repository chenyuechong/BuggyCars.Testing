Feature: UserProfile
update firstname and lastName in Profile 

Background: 
Given user open BuggyCars website
And  user use valid credential login
   | UserName	  | Password	|
   | AmandaChen   | AaBbCc123!  |
And user already in Profile Page

@profile
Scenario: update firstName and lastName then firstname and lastname will be changed after user refresh page
	Given user has profile details
	| userName   | firstName | lastName |
	| AmandaChen | AmandaChen| Chen     |
	When change name to 
	| userName   | FirstName | lastName |
	| AmandaChen |   Amanda  | C        |
	And refresh page 
	Then user should see details
	| userName   | FirstName | lastName |
	| AmandaChen |   Amanda  | C        |
	And restore test data
	| userName   | FirstName | lastName |
	| AmandaChen | AmandaChen| Chen     |