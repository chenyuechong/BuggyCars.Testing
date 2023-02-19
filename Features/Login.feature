Feature: Login
verify use invalid and valid credential to login

Background: 
	Given user open BuggyCars website

@Login
Scenario: enter invalid credential then error message should be present
   When user use invalid credential to login
   | UserName     | Password	|
   |  test1       | AaBbCc123!  |
   Then login failed

@Login
Scenario: use valid credential 
   When user use valid credential to login
   | UserName	  | Password	|
   | AmandaChen   | AaBbCc123!  |
   Then user should see first name in the page
 
@Logout
Scenario: use logout
   When user use valid credential to login
   | UserName	  | Password	|
   | AmandaChen   | AaBbCc123!  |  
   When user click logout
   Then register button shows in page
